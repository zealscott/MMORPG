using Common;
using System;
using System.Collections;

namespace Backend.Game
{
    public class Treasure
    {
        public int treasureId;
        public string name;
        public int mainType;        // helmet:1\armour:2\leftWeapon:3\rightWeapon:4\shield:5\magicPortion:6
        public int speed;
        public int intelligence;
        public int attack;
        public int defense;

        public DTreasure ToDTreasure()
        {
            DTreasure treasure = new DTreasure()
            {
                treasureId = this.treasureId,
                name = this.name,
                mainType = this.mainType,
                speed = this.speed,
                intelligence = this.intelligence,
                attack = this.attack,
                defense = this.defense
            };
            return treasure;
        }

    }
}
