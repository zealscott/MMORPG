using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CAddFriend : Message
    {
        public CAddFriend() : base(Command.C_ADD_FRIEND) { }
        
        public bool success;
        public string friendName;
             
    }
}
