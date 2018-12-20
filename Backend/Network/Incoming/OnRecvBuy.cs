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
            string buyer_ = player.name;
            int price_;
            string seller_;

            // transaction for gold treasures
            if (request.totalGold > 0)
            {
                SBuyGoldResult goldMessage = new SBuyGoldResult()
                {
                    success = true
                };

                // for each gold treasure is a transaction
                foreach (string goods in request.goldGoods)
                {
                    price_ = backMall[goods].price;
                    seller_ = backMall[goods].ownerName;
                    tmpJudge = connect.GoldTransaction(buyer_, seller_, price_, goods);
                    if (tmpJudge == 0)
                    {
                        goldMessage.success = false;
                    }
                    else
                    {
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
            if (request.totalSilver > 0)
            {
                // add treasure to package
                List<string> NewsilverTs = new List<string>();
                foreach(KeyValuePair<string, int> goods in request.newSilverGoods)
                {
                    NewsilverTs.Add(string.Format("('{0}','{1}','{2}')", buyer_, goods.Key, goods.Value));
                }
                tmpJudge = connect.BuyNewSilverTreasure(NewsilverTs);
                //if (tmpJudge == 0)
                //    return;

                foreach (KeyValuePair<string, int> goods in request.oldSilverGoods)
                {
                    tmpJudge = connect.UpdateTreasureNum(buyer_, goods.Key, goods.Value);
                }

                // minus silver coins
                tmpJudge = connect.UpdateSilverNum(buyer_, request.totalSilver);
                player.SilverNum -= request.totalSilver;
            }
        }
    }
}
