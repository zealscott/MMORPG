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
            List<string> friendRequest = connect.GetFriendRequest(player.user);
            if (friendRequest.Count > 0)
            {
                SFindFriendRequests requestList = new SFindFriendRequests()
                {
                    requests = new List<string>(friendRequest)
                };
                channel.Send(requestList);
            }         
        }
        
    }
}
