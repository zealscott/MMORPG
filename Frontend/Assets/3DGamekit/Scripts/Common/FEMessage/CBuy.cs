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
        public Dictionary<string, int> newSilverGoods;       // name and number
        public Dictionary<string, int> oldSilverGoods;      // name and number
        public List<string> goldGoods;                      // name 
    }
}
