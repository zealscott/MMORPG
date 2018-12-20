using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D.Network

{
    public partial class Incoming
    {
        private void OnRecvPackage(IChannel channel, Message message)
        {
            SPackage msg = message as SPackage;
            foreach(KeyValuePair<string, DTreasurePackage> tmp in msg.goods)
            {
                TreasureInfo.playerTreasure.Add(tmp.Key, new TreasurePackage().FromDTreasurePackage(tmp.Value));
            }
        }
    }
}
