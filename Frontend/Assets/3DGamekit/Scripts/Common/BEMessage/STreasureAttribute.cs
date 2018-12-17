using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class STreasureAttribute : Message
    {
        public STreasureAttribute() : base(Command.S_TREASURE_ATTRIBUTE) { }
        public Dictionary<string, DTreasure> treasureAttri;

        //public Dictionary<string, DTreasureOwnership> playerTreasure;
    }
}
