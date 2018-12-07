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
                currentHP = player.currentHP,
                level = player.level,
                intelligence = player.intelligence,
                speed = player.speed,
                attack = player.attack,
                defense = player.defense
            };
            channel.Send(attrMessage);

            // add online player
            OnlinePlayers.Add(player.entityId, player);
            // send oneline player to frontend
            Dictionary<int, string> SendDic = new Dictionary<int, string>();

            foreach (KeyValuePair<int, Player> tmp in OnlinePlayers)
            {
                SendDic.Add(tmp.Key, tmp.Value.user);
                Console.WriteLine("Add user:{0}", tmp.Value.user);
            }
            SFindFriends response = new SFindFriends() { friends = SendDic };
            player.Broadcast(response);

            //for debug
            //Console.WriteLine("recv player enter: player speed:{0}", player.speed);
        }
    }
}
