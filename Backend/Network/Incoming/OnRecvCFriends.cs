using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvCFriends(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvCFriends");
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();
            SFriends friendList = new SFriends()
            {
                friends = new List<string>(connect.GetFriends(player.user))
            };
            channel.Send(friendList);
        }
        
    }
}
