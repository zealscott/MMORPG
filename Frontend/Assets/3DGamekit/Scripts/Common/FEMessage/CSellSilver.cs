using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CSellSilver : Message
    {
        public CSellSilver() : base(Command.C_SELL_SILVER) { }
        public int silverCoin;
        public bool sellAll;
        public int remainNum;
        public string goods;
    }
}
