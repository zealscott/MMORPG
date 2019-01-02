using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CNotSell : Message
    {
        public CNotSell() : base(Command.C_NOT_SELL) { }
        public string goodsName;
    }
}
