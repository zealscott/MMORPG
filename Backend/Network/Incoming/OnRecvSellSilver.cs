using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvSellSilver(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvSellSilver");
            CSellSilver request = message as CSellSilver;
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();
            int result;

            player.SilverNum = request.silverCoin;
            result = connect.UpdateSilverNum(player.user, request.silverCoin);
            if (result == 0)
                Console.WriteLine("update silverNum failure");

            if(request.sellAll)
            {
                // delete goods from package
                result = connect.DBDeleteFromPackage(player.user, request.goods);
                if (result == 0)
                    Console.WriteLine("delete silver goods failure");
            }
            else
            {
                // modify the goods number in package
                result = connect.UpdateTreasureNum(player.user, request.goods, request.remainNum);
                if (result == 0)
                    Console.WriteLine("update silver goodsNum failure");
            }
        }    
    }
}
