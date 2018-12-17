using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SSilverT : Message
    {
        public SSilverT() : base(Command.S_SILVER_TREASURE) { }
        public Dictionary<string, int> silverT;
    }
}
