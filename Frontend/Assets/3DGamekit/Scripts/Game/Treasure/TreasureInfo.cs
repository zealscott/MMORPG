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

        // silver ones, the num is always infinite, name and price 
        static public Dictionary<string, int> silverT = new Dictionary<string, int>();

        // golden ones, which own to players
        static public Dictionary<string, TreasureOwnership> goldenT = new Dictionary<string, TreasureOwnership>();

        // player's treasures
        static public Dictionary<string, TreasureOwnership> playerTreasure = new Dictionary<string, TreasureOwnership>();
    }
}
