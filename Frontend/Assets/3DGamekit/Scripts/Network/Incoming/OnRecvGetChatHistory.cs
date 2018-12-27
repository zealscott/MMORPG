using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvGetChatHistory(IChannel channel, Message message)
        {
            SGetChatHistory msg = message as SGetChatHistory;
            PlayerInfo.chatHistory.Add(msg.chatWith, msg.chatLog);
            PlayerInfo.chatHistoryBitMap.Add(msg.chatWith, msg.bitWho);
        }
    }
}
