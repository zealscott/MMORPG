using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CFriends : Message
    {
        public CFriends() : base(Command.C_FRIENDS) { }      
    }
}
