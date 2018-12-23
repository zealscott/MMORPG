using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CMall : Message
    {
        public CMall() : base(Command.C_MALL) { }      
    }
}
