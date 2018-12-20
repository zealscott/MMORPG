using Common;
using System;
using System.Collections;

namespace Backend.Game
{
    public class TreasurePackage
    {
        public bool wear;
        public int number;


        public DTreasurePackage ToDTreasurePackagep()
        {
            DTreasurePackage treasurePackage = new DTreasurePackage()
            {             
                wear = this.wear,
                number = this.number
            };
            return treasurePackage;
        }

    }
}
