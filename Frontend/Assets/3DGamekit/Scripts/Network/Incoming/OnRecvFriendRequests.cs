using UnityEngine;
using Common;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvFriendRequests(IChannel channel, Message message)
        {
            SFindFriendRequests msg = message as SFindFriendRequests;
            PlayerInfo.friendRequest = new System.Collections.Generic.List<string>(msg.requests);
        }
    }
}
