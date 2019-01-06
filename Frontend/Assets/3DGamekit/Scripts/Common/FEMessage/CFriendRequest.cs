using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CFriendRequest : Message
    {
        public CFriendRequest() : base(Command.C_FRIEND_REQUEST) { }      
    }
}
