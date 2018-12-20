using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SPackage : Message
    {
        public SPackage() : base(Command.S_PACKAGE) { }
        public Dictionary<string, DTreasurePackage> goods;
    }
}
