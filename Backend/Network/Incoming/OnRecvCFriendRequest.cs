using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvCFriendRequest(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvCFriendRequest");
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();
            SFindFriendRequests requestList = new SFindFriendRequests()
            {
                requests = new List<string>(connect.GetFriendRequest(player.user))
            };
            channel.Send(requestList);
        }
        
    }
}
