using UnityEngine;
using Common;
using System.Collections.Generic;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvSellSuccess(IChannel channel, Message message)
        {
            SSendToSeller msg = message as SSendToSeller;
            //MessageBox.Show("sell " + msg.goodsName + " successfully ");
            PlayerInfo.GoldNum = msg.goldCoin;
            //if (TreasureInfo.treasureMall.ContainsKey(msg.goodsName))
            //    TreasureInfo.treasureMall.Remove(msg.goodsName);
        }
    }
}
