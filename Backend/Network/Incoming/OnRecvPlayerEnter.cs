using Common;
using Backend.Game;
using System;

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


            //for debug
            //Console.WriteLine("recv player enter: player speed:{0}", player.speed);
        }
    }
}
