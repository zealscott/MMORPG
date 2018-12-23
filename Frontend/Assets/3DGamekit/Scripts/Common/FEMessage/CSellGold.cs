using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CSellGold : Message
    {
        public CSellGold() : base(Command.C_SELL_GOLD) { }
        public string goods;
        public int price;
    }
}
