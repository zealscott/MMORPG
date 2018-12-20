using Common;
using Gamekit3D.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Gamekit3D
{
    public class TreasurePackage
    {
        public bool wear;
        public int number;


        public TreasurePackage FromDTreasurePackage(DTreasurePackage dTreasurePackage)
        {
            this.wear = dTreasurePackage.wear;
            this.number = dTreasurePackage.number;
            return this;
        }
    }
}
