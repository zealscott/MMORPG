using Common;
using System;
using System.Collections;

namespace Backend.Game
{
    public class TreasureOwnership
    {
        public int treasureId;
        public int ownerId;
        public bool wear;
        public int price;       // price = 0 means not onsell
        public int number;
        public int sellNum;


        public DTreasureOwnership ToDTreasureOwnership()
        {
            DTreasureOwnership treasureOwnership = new DTreasureOwnership()
            {
                treasureId = this.treasureId,
                wear = this.wear,
                price = this.price,
                number = this.number,
                sellNum = this.sellNum,
                ownerId = this.ownerId
            };
            return treasureOwnership;
        }

    }
}
