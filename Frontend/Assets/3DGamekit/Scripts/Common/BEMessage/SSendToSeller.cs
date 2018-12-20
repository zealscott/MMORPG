using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SSendToSeller : Message
    {
        public SSendToSeller() : base(Command.S_SEND_TO_SELLER) { }
        public int price;
        public string goodsName;
    }
}
