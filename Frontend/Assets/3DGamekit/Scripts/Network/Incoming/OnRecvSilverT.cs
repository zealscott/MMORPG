using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D.Network

{
    public partial class Incoming
    {
        private void OnRecvSilverT(IChannel channel, Message message)
        {

            MessageBox.Show("receive silver treasure info");

            SSilverT msg = message as SSilverT;
            TreasureInfo.silverT = new Dictionary<string, int>(msg.silverT);
        }
    }
}
