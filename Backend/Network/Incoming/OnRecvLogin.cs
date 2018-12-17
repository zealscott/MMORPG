using Common;
using Backend.Game;
using System.Data.Common;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvLogin(IChannel channel, Message message)
        {

            CLogin request = message as CLogin;
            string scene = "Level1";

            // read from database
            ConnectDB connect = new ConnectDB();
            int playerID = connect.LogIn(request.user, request.password);
            if (playerID == 0)
            {
                ClientTipInfo(channel, "Wrong UserName or Passwd!");
                return;
            }
            if (OnlinePlayers.ContainsKey(request.user))
            {
                ClientTipInfo(channel, "user has logged in!");
                return;
            }

            SPlayerEnter response = new SPlayerEnter()
            {
                user = request.user,
                token = request.user,
                scene = scene
            };
            channel.Send(response);

            Player player = new Player(channel) { scene = scene };
            DEntity dentity = World.Instance.EntityData["Ellen"];
            player.FromDEntity(dentity);
            player.forClone = false;
            connect.GetPlayerAttri(playerID, player);
            Console.WriteLine("user: {0} login", player.user);

            // DOTO: Add xyz from db

            
        }
    }
}
