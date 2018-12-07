using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SFindFriends : Message
    {
        public SFindFriends() : base(Command.S_FIND_FRIENDS) { }
        public Dictionary<int, string> friends;
    }
}
