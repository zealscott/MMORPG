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

            MessageBox.Show("receive treasure info");

            STreasureAttribute msg = message as STreasureAttribute;

            foreach (KeyValuePair<string, DTreasure> tmp in msg.treasureAttri)
            {
                TreasureInfo.treasureAttri.Add(tmp.Key, new Treasure().FromDTreasure(tmp.Value));
                MessageBox.Show("receive: " + tmp.Key);
            }

            //foreach (KeyValuePair<string, DTreasureOwnership> tmp in msg.goldenT)
            //{
            //    TreasureInfo.goldenT.Add(tmp.Key, new TreasureOwnership().FromDTreasureOwnership(tmp.Value));
            //    MessageBox.Show("receive: " + tmp.Key);
            //}

            //TreasureInfo.silverT = new Dictionary<string, int>(msg.silverT);


            //foreach (KeyValuePair<string, DTreasureOwnership> tmp in msg.playerTreasure)
            //{
            //    TreasureInfo.playerTreasure.Add(tmp.Key, new TreasureOwnership().FromDTreasureOwnership(tmp.Value));
            //    MessageBox.Show("receive: " + tmp.Key);
            //}


        }
    }
}
