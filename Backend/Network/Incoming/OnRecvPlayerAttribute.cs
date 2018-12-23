using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvPlayerAttribute(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvPlayerAttribute");
            CPlayerAttribute request = message as CPlayerAttribute;
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();

            // resolve message
            int intelligence = request.intelligence;
            int speed = request.speed;
            int attack = request.attack;
            int defense = request.defense;
            Console.WriteLine("palyer attribute: " + speed + intelligence + attack + defense);

            // modify player's attribute
            player.intelligence = intelligence;
            player.speed = speed;
            player.attack = attack;
            player.defense = defense;

            // modify database
            int result = connect.UpdatePlayerAttribute(player.user, speed, intelligence, attack, defense);
            if (result == 0)
                Console.WriteLine("Update player attribute failure.");
        }    
    }
}
