using Common;
using System;
using System.Collections;

namespace Backend.Game
{
    public class TreasureMall
    {
        public string ownerName;
        public int price;
        public bool isGold;


        public DTreasureMall ToTreasureMall()
        {
            DTreasureMall treasureMall = new DTreasureMall()
            {
                ownerName = this.ownerName,
                price = this.price,
                isGold = this.isGold
            };
            return treasureMall;
        }

    }
}
