using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvSellGold(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvSellGold");
            CSellGold request = message as CSellGold;
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();
            int result;

            string goodsName = request.goods;
            string playerName = player.user;
            int goodPrice = request.price;

            // delete from package
            result = connect.DBDeleteFromPackage(playerName, goodsName);
            if (result == 0)
                Console.WriteLine("delete gold goods from package failure");

            // add to mall
            DTreasureMall tmp = new DTreasureMall() {ownerName = playerName, price = goodPrice, isGold = true};
            backMall.Add(goodsName, tmp);
            result = connect.DBAddToMall(goodsName, playerName, true, goodPrice);
            if (result == 0)
                Console.WriteLine("add gold goods to mall failure");
        }    
    }
}
