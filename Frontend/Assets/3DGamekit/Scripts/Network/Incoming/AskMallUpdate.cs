using Common;
using System.Threading;
using UnityEngine;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        public void AskMallUpdate(object Internal)
        {
            while (true)
            {
                Thread.Sleep((int)Internal);
                //Debug.Log("sleep 1 mins");
                if (TreasureInfo.treasureAttri.Count > 0)
                {
                    CMall msg = new CMall();
                    MyNetwork.Send(msg);
                }               
            }
        }
    }
}
