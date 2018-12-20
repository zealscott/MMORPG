using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D.Network

{
    public partial class Incoming
    {
        private void OnRecvTreasureAttribute(IChannel channel, Message message)
        {
            STreasureAttribute msg = message as STreasureAttribute;

            foreach (KeyValuePair<string, DTreasure> tmp in msg.treasureAttri)
            {
                TreasureInfo.treasureAttri.Add(tmp.Key, new Treasure().FromDTreasure(tmp.Value));
            }
        }
    }
}
