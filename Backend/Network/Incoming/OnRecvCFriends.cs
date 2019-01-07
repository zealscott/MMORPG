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
            List<string> friends = connect.GetFriends(player.user);
            if (friends.Count > 0)
            {
                SFriends friendList = new SFriends()
                {
                    friends = new List<string>(friends)
                };
                channel.Send(friendList);
            }            
        }
        
    }
}
