using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvBuy(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvBuy");
            CBuy request = message as CBuy;
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();
            int tmpJudge = 0;
            string buyer_ = player.user;
            int price_;
            string seller_;
            Dictionary<string, int> newSilverGoods = new Dictionary<string, int>();
            Dictionary<string, int> oldSilverGoods = new Dictionary<string, int>();
            List<string> goldGoods = new List<string>();

            // resolve message
            foreach (DTreasureBuy goods in request.Goods)
            {
                if (goods.type == 0)
                    goldGoods.Add(goods.name);
                else if (goods.type == 1)
                    newSilverGoods.Add(goods.name, goods.number);
                else if (goods.type == 2)
                    oldSilverGoods.Add(goods.name, goods.number);
            }

            // transaction for gold treasures
            if (request.totalGold > 0)
            {
                SBuyGoldResult goldMessage = new SBuyGoldResult();
                // for each gold treasure is a transaction
                foreach (string goods in goldGoods)
                {
                    price_ = backMall[goods].price;
                    seller_ = backMall[goods].ownerName;
                    Console.WriteLine("gold transcation: buyer: " + buyer_ + " seller: " + seller_ + " price: " + price_ + " goods: " + goods);
                    tmpJudge = connect.GoldTransaction(buyer_, seller_, price_, goods);
                    Console.WriteLine("gold insert result: " + tmpJudge);
                    if (tmpJudge == 0)
                    {
                        goldMessage.success = false;
                    }
                    else
                    {
                        goldMessage.success = true;
                        goldMessage.goodsName = goods;
                        // change player's goldCoin
                        player.GoldNum -= price_;
                        // send to seller
                        if (OnlinePlayers.ContainsKey(seller_))
                        {
                            SSendToSeller sellerMsg = new SSendToSeller()
                            {
                                price = price_,
                                goodsName = goods
                            };
                            Player toPlayer = OnlinePlayers[seller_];
                            toPlayer.connection.Send(sellerMsg);
                            toPlayer.GoldNum += price_;
                        }
                        // remove from backMall
                        backMall.Remove(goods);
                    }
                    channel.Send(goldMessage);
                }
            }

            // deal with silver goods
            Console.WriteLine(request.totalSilver);
            if (request.totalSilver > 0)
            {
                // add treasure to package
                if (newSilverGoods.Count != 0)
                {
                    List<string> NewsilverTs = new List<string>();
                    foreach (KeyValuePair<string, int> goods in newSilverGoods)
                    {
                        Console.WriteLine("new silver: buyer:" + buyer_ + " goods: " + goods.Key + " num: " + goods.Value);
                        NewsilverTs.Add(string.Format("('{0}','{1}','{2}')", buyer_, goods.Key, goods.Value));
                        connect.AddTrade(goods.Key, "mall", buyer_, goods.Value, backMall[goods.Key].price);
                    }
                    tmpJudge = connect.BuyNewSilverTreasure(NewsilverTs);
                    Console.WriteLine("new silver insert result: " + tmpJudge);
                }

                if (oldSilverGoods.Count != 0)
                {
                    foreach (KeyValuePair<string, int> goods in oldSilverGoods)
                    {
                        Console.WriteLine("old silver: buyer:" + buyer_ + " goods: " + goods.Key + " num: " + goods.Value);
                        tmpJudge = connect.UpdateTreasureNum(buyer_, goods.Key, goods.Value);
                        connect.AddTrade(goods.Key, "mall", buyer_, goods.Value, backMall[goods.Key].price);
                        Console.WriteLine("old silver insert result: " + tmpJudge);
                    }
                }                

                // minus silver coins
                Console.WriteLine("player: " + buyer_ + " silverNum minus: " + request.totalSilver);
                tmpJudge = connect.UpdateSilverNum(buyer_, request.totalSilver);
                Console.WriteLine("silverNum update result: " + tmpJudge);
                player.SilverNum -= request.totalSilver;
            }
        }
    }
}
