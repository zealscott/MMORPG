using Common;
using Gamekit3D.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Gamekit3D
{
    public class TreasureOwnership
    {
        public int treasureId;
        public int ownerId;
        public bool wear;
        public int price;
        public int number;
        public int sellNum;
        

        public TreasureOwnership FromDTreasureOwnership(DTreasureOwnership dTreasureOwnership)
        {
            this.treasureId = dTreasureOwnership.treasureId;
            this.wear = dTreasureOwnership.wear;
            this.price = dTreasureOwnership.price;
            this.number = dTreasureOwnership.number;
            this.sellNum = dTreasureOwnership.sellNum;
            this.ownerId = dTreasureOwnership.ownerId;
            return this;
        }
    }
}
