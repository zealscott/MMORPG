using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SGoldenT : Message
    {
        public SGoldenT() : base(Command.S_GOLDEN_TREASURE) { }
        public Dictionary<string, DTreasureOwnership> goldenT;
    }
}
