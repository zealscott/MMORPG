using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SMall : Message
    {
        public SMall() : base(Command.S_MALL) { }
        public Dictionary<string, DTreasureMall> goods;
    }
}
