using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvTreasureWear(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvTreasureWear");
            CTreasureWear request = message as CTreasureWear;
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();
            int result;

            // modify player's attribute
            foreach(KeyValuePair<string, bool> kv in request.treasureWear)
            {
                Console.WriteLine("update treasure wear: " + player.user + kv.Key + kv.Value);
                result = connect.UpdateTreasureWear(player.user, kv.Key, kv.Value);
                if (result == 0)
                    Console.WriteLine("Modify wear treasure status failure.");
            }
        }    
    }
}
