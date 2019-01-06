using UnityEngine;
using Common;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvFriends(IChannel channel, Message message)
        {
            SFriends msg = message as SFriends;
            PlayerInfo.friends = new System.Collections.Generic.List<string>(msg.friends);
        }
    }
}
