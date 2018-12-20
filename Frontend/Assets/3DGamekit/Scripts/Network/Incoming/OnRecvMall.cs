using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D.Network

{
    public partial class Incoming
    {
        private void OnRecvMall(IChannel channel, Message message)
        {
            SMall msg = message as SMall;
            foreach (KeyValuePair<string, DTreasureMall> tmp in msg.goods)
            {
                TreasureInfo.treasureMall.Add(tmp.Key, new TreasureMall().FromDTreasureMall(tmp.Value));
            }
        }
    }
}
