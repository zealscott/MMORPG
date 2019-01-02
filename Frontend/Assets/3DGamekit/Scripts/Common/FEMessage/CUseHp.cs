using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CUseHp : Message
    {
        public CUseHp() : base(Command.C_USE_HP) { }
        public bool toDelete;
        public int ownNum;
    }
}
