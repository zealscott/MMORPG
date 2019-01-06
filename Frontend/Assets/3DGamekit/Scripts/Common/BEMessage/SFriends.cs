using Gamekit3D;
using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SFriends : Message
    {
        public SFriends() : base(Command.S_FRIENDS) { }
        public List<string> friends;
    }
}
