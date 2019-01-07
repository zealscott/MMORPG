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
                defense = player.defense,
                GoldNum = player.GoldNum,
                SilverNum = player.SilverNum
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


            // send treasure attributes   
            ConnectDB connect = new ConnectDB();
            if (treasureAttributes.Count == 0)
            {
                treasureAttributes = new Dictionary<string, DTreasure>(connect.GetTreasureAttri());
            }
            STreasureAttribute treasureAttribute = new STreasureAttribute()
            {
                treasureAttri = new Dictionary<string, DTreasure>(treasureAttributes)
            };
            channel.Send(treasureAttribute);

            // send mall
            if (backMall.Count == 0)
            {
                backMall = new Dictionary<string, DTreasureMall>(connect.DBGetMall());
            }
            SMall mall = new SMall()
            {
                goods = new Dictionary<string, DTreasureMall>(backMall)
            };
            channel.Send(mall);

            // send package
            SPackage package = new SPackage()
            {
                goods = new Dictionary<string, DTreasurePackage>(connect.DBGetPackage(player.user))
            };
            channel.Send(package);

            // send friends
            SFriends friendList = new SFriends()
            {
                friends = new List<string>(connect.GetFriends(player.user))
            };
            channel.Send(friendList);

            // send friend requests
            SFindFriendRequests requestList = new SFindFriendRequests()
            {
                requests = new List<string>(connect.GetFriendRequest(player.user))
            };
            channel.Send(requestList);
        }
    }
}
