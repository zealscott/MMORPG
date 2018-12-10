using UnityEngine;
using Common;
using System.Collections.Generic;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvChatMessage(IChannel channel, Message message)
        {
            SChatMessage msg = message as SChatMessage;

            if (PlayerInfo.chatMessage.ContainsKey(msg.fromName))
            {
                PlayerInfo.chatMessage[msg.fromName].Add(msg.chatContext);
            }
            else
            {
                List<string> tmp = new List<string>
                {
                    msg.chatContext
                };
                PlayerInfo.chatMessage.Add(msg.fromName, tmp);
            }

            MessageBox.Show("receive new message from " + msg.fromName);
        }
    }
}
