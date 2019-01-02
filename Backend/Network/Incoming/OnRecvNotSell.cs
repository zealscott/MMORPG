using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvNotSell(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvNotSell");
            CNotSell request = message as CNotSell;
            Player player = (Player)channel.GetContent();

            // remove from backMall
            backMall.Remove(request.goodsName);
           
            ConnectDB connect = new ConnectDB();
            connect.RemoveFromMall(player.user, request.goodsName);
            connect.AddToPackage(player.user, request.goodsName);
        }    
    }
}
