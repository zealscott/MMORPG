using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CBuy : Message
    {
        public CBuy() : base(Command.C_BUY) { }
        public int totalGold;
        public int totalSilver;
        public List<DTreasureBuy> Goods;
    }
}
