using Gamekit3D.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Gamekit3D
{
    public class TreasureInfo
    {
        // all treasures' attribute
        static public Dictionary<string, Treasure> treasureAttri = new Dictionary<string, Treasure>();

        // goods in mall
        static public Dictionary<string, TreasureMall> treasureMall = new Dictionary<string, TreasureMall>();

        // player's treasures
        static public Dictionary<string, TreasurePackage> playerTreasure = new Dictionary<string, TreasurePackage>();

        // player's wear or put off modified treasures
        static public Dictionary<string, bool> modifiedTreasure = new Dictionary<string, bool>();
    }
}
