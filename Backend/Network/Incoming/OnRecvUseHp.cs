using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvUseHp(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvUseHp");
            CUseHp msg = message as CUseHp;
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();
            if (msg.toDelete)
            {
                connect.DBDeleteFromPackage(player.user, "Elixir_3");
            }
            else
            {
                connect.UpdateTreasureNum(player.user, "Elixir_3", msg.ownNum);
            }
        }
    }
}
