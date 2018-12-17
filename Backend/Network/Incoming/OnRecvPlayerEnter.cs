using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvPlayerEnter(IChannel channel, Message message)
        {
            CPlayerEnter request = message as CPlayerEnter;
            Player player = (Player)channel.GetContent();
            Scene scene = World.Instance.GetScene(player.scene);
            // add the player to the scene
            player.Spawn();
            scene.AddEntity(player);

            // send player attributes 
            SPlayerAttribute attrMessage = new SPlayerAttribute()
            {
                playerId = player.entityId,
                name = player.user,
                currentHP = player.currentHP,
                level = player.level,
                intelligence = player.intelligence,
                speed = player.speed,
                attack = player.attack,
                defense = player.defense
            };
            channel.Send(attrMessage);

            // add online player
            OnlinePlayers.Add(player.user, player);
            // send oneline player to frontend
            Dictionary<int, string> SendDic = new Dictionary<int, string>();

            foreach (KeyValuePair<string, Player> tmp in OnlinePlayers)
            {
                SendDic.Add(tmp.Value.entityId, tmp.Key);
                Console.WriteLine("contains user:{0}", tmp.Key);
            }
            SFindFriends response = new SFindFriends() { friends = SendDic };
            player.Broadcast(response);

            Console.WriteLine("send find friends");

            //for debug
            //Console.WriteLine("recv player enter: player speed:{0}", player.speed);

            // debug: send treasure to frontend
            //Treasure test = new Treasure()
            //{
            //    treasureId = 1,
            //    name = "Amulet_1",
            //    attack = 10
            //};
            //STreasureAttribute testInfo = new STreasureAttribute() { };
            //testInfo.treasureAttri = new Dictionary<string, DTreasure>();
            //testInfo.treasureAttri.Add(test.name, test.ToDTreasure());
            //TreasureOwnership test2 = new TreasureOwnership()
            //{
            //    price = 10
            //};
            //testInfo.goldenT = new Dictionary<string, DTreasureOwnership>();
            //testInfo.goldenT.Add(test.name, test2.ToDTreasureOwnership());
            //channel.Send(testInfo);

            
            ConnectDB connect = new ConnectDB();
            STreasureAttribute testAttr = new STreasureAttribute() { };
            testAttr.treasureAttri = new Dictionary<string, DTreasure>(connect.GetTreasureAttri());
            foreach (KeyValuePair<string, DTreasure> tmp in testAttr.treasureAttri)
            {
                Console.WriteLine("from DB attribute: " + tmp.Key);
            }
            channel.Send(testAttr);

            SSilverT testSilver = new SSilverT() { };
            testSilver.silverT = new Dictionary<string, int>(connect.GetSilverT());
            foreach (KeyValuePair<string, int> tmp in testSilver.silverT)
            {
                Console.WriteLine("from DB silver: " + tmp.Key);
            }
            channel.Send(testSilver);

            SGoldenT testGolden = new SGoldenT() { };
            testGolden.goldenT = new Dictionary<string, DTreasureOwnership>(connect.GetGoldenT());
            foreach (KeyValuePair<string, DTreasureOwnership> tmp in testGolden.goldenT)
            {
                Console.WriteLine("from DB golden: " + tmp.Key);
            }
            channel.Send(testGolden);
        }
    }
}
