using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class SGetChatHistory : Message
    {
        public SGetChatHistory() : base(Command.S_GETCHATHISTORY) { }
        public List<string> chatLog;
        public string chatWith;
        public string bitWho;  // using 0/1 to identify who sent this message
    }
}
