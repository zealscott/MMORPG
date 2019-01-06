using Common;
using System.Threading;
using UnityEngine;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        public void AskFriendRequestUpdate(object Internal)
        {
            while (true)
            {
                Thread.Sleep((int)Internal);
                if (PlayerInfo.friendRequest.Count > 0)
                {
                    CFriendRequest msg = new CFriendRequest();
                    MyNetwork.Send(msg);
                }               
            }
        }
    }
}
