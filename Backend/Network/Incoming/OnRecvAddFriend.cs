using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvAddFriend(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvAddFriend");
            CAddFriend request = message as CAddFriend;
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();

            string name1 = player.user;
            string name2 = request.friendName;

            if (request.success)
            {
                // add friends               
                connect.AddFriend(name1, name2);
                connect.AddFriend(name2, name1);
            }

            // delete add friend request
            connect.DeleteFromFriendRequest(name2, name1);
        }    
    }
}
