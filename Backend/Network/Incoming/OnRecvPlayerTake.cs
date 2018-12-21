﻿using System.Diagnostics;
using Common;
using Backend.Game;
using System;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvPlayerTake(IChannel channel, Message message)
        {
            Console.WriteLine("OnRecvPlayerTake");
            CPlayerTake request = message as CPlayerTake;
            Player player = (Player)channel.GetContent();

            Entity target = World.Instance.GetEntity(request.targetId);
            if (target == null || !(target is Item))
            {
                Trace.WriteLine("cannot find target entity");
                return;
            }

            Item item = (Item)target;
            player.TakeItem(item);
        }
    }
}
