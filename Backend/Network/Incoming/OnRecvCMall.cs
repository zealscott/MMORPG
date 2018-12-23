using Common;
using Backend.Game;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvCMall(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvCMall");
            SMall msg = new SMall();
            msg.goods = new Dictionary<string, DTreasureMall>(backMall);
            channel.Send(msg);
        }    
    }
}
