using Common;
using Gamekit3D.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Gamekit3D
{
    public class TreasureMall
    {
        public string ownerName;
        public int price;
        public bool isGold;


        public TreasureMall FromDTreasureMall(DTreasureMall dTreasureMall)
        {
            this.price = dTreasureMall.price;
            this.ownerName = dTreasureMall.ownerName;
            this.isGold = dTreasureMall.isGold;
            return this;
        }
    }
}
