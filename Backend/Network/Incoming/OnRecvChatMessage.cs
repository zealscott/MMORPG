using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvChatMessage(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvChatMessage");
            CChatMessage request = message as CChatMessage;
            Player player = (Player)channel.GetContent();
            string toWho = request.toName;
            string content = request.chatContext;

            SChatMessage chatMessage = new SChatMessage()
            {
                fromName = player.user,
                chatContext = content,
            };

            // for debug
            Console.WriteLine("recieve chat msg from :{0}", player.user);

            if (toWho == "WorldChat")
            {
                chatMessage.fromName = toWho;
                player.Broadcast(chatMessage, true);
            }
                
                
            else
            {
                Player toPlayer = OnlinePlayers[toWho];
                toPlayer.connection.Send(chatMessage);
            }

            ChatHistory.Add(string.Format("('{0}','{1}','{2}','{3}')", player.user, toWho, content, System.DateTime.Now));
        }
    }
}
