using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SFindFriendRequests : Message
    {
        public SFindFriendRequests() : base(Command.S_FIND_FRIEND_REQUEST) { }
        public List<string> requests;
    }
}
