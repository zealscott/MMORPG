using UnityEngine;
using Common;
using System.Collections.Generic;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvBuyGold(IChannel channel, Message message)
        {
            SBuyGoldResult msg = message as SBuyGoldResult;
            string goods = msg.goodsName;
            if (msg.success)
            {
                PlayerInfo.GoldNum -= TreasureInfo.treasureMall[goods].price;
                TreasureInfo.treasureMall.Remove(goods);

                TreasurePackage tmp = new TreasurePackage() { number = 1, wear = false };
                TreasureInfo.playerTreasure.Add(goods, tmp);
            }
            else
                MessageBox.Show("Buy " + goods + " failure");
        }
    }
}
