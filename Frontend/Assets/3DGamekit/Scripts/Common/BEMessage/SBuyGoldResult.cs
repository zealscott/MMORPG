using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SBuyGoldResult : Message
    {
        public SBuyGoldResult() : base(Command.S_BUY_GOLD_RESULT) { }
        public bool success;
        public string goodsName;
    }
}
