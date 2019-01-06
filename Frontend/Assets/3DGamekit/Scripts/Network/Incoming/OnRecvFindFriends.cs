using UnityEngine;
using Common;
using System.Collections.Generic;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvFindFriends(IChannel channel, Message message)
        {
            SFindFriends msg = message as SFindFriends;
            PlayerInfo.online = new Dictionary<int, string>(msg.friends);
            PlayerInfo.online.Remove(PlayerInfo.playerId);
        }
    }
}
