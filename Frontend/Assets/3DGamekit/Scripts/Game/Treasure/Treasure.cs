using Common;
using Gamekit3D.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Gamekit3D
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

        public Treasure FromDTreasure(DTreasure dTreasure)
        {
            this.treasureId = dTreasure.treasureId;
            this.name = dTreasure.name;
            this.mainType = dTreasure.mainType;
            this.speed = dTreasure.speed;
            this.intelligence = dTreasure.intelligence;
            this.attack = dTreasure.attack;
            this.defense = dTreasure.defense;
            return this;
        }
    }
}
