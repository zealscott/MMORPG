using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CGetChatHistory : Message
    {
        public CGetChatHistory() : base(Command.C_GETCHATHISTORY) { }
        public string chatWithName;
        public int maxChatNum;
    }
}
