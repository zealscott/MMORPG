using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CTreasureWear : Message
    {
        public CTreasureWear() : base(Command.C_TREASURE_WEAR) { }
        public Dictionary<string, bool> treasureWear; 
    }
}
