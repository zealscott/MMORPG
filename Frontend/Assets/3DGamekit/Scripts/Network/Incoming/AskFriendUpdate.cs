using Common;
using System.Threading;
using UnityEngine;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        public void AskFriendUpdate(object Internal)
        {
            while (true)
            {
                Thread.Sleep((int)Internal);
                if (PlayerInfo.friends.Count > 0)
                {
                    CFriends msg = new CFriends();
                    MyNetwork.Send(msg);
                }               
            }
        }
    }
}
