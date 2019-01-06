using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CSearchAddFriend : Message
    {
        public CSearchAddFriend() : base(Command.C_SEARCH_ADD_FRIEND) { }
        public string name;
    }
}
