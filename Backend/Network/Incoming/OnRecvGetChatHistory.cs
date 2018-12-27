using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvGetChatHistory(IChannel channel, Message message)
        {
            CGetChatHistory request = message as CGetChatHistory;
            Player player = (Player)channel.GetContent();
            string chatWithName = request.chatWithName;

            int maxChatNum = request.maxChatNum;
            // response content
            char[] fromWhoArray = new string('1', maxChatNum + 1).ToCharArray();
            List<string> chatLog = new List<string>();

            ConnectDB connect = new ConnectDB();
            List<KeyValuePair<string, string>> content = connect.GetChatHistory(player.user, chatWithName, maxChatNum);
            for (int i = content.Count - 1; i >= 0; i--)
            {
                var each = content[i];
                if (each.Key.Equals(chatWithName))
                    fromWhoArray[content.Count - i - 1] = '0';
                chatLog.Add(each.Value);
            }

            // construct message to send
            SGetChatHistory chatHistoryMessage = new SGetChatHistory()
            {
                chatLog = chatLog,
                bitWho = new string(fromWhoArray),
                chatWith = chatWithName
            };


            channel.Send(chatHistoryMessage);
        }
    }
}
