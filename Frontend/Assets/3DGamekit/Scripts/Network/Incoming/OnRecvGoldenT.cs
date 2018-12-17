using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D.Network

{
    public partial class Incoming
    {
        private void OnRecvGoldenT(IChannel channel, Message message)
        {

            MessageBox.Show("receive golden treasure info");

            SGoldenT msg = message as SGoldenT;
            foreach (KeyValuePair<string, DTreasureOwnership> tmp in msg.goldenT)
            {
                TreasureInfo.goldenT.Add(tmp.Key, new TreasureOwnership().FromDTreasureOwnership(tmp.Value));
                MessageBox.Show("receive: " + tmp.Key);
            }
        }
    }
}
