using Common;
using Backend.Game;
using System.Data.Common;
using System;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvLogin(IChannel channel, Message message)
        {
            Console.WriteLine("on rece login");
            CLogin request = message as CLogin;
            string scene = "Level1";
            
            // read from database
            ConnectDB connect = new ConnectDB();
            int playerID = 0;
            while (playerID == 0)
            {
                playerID = connect.LogIn(request.user, request.password);
                if (playerID > 0)
                    break;
                ClientTipInfo(channel, "Wrong UserName or Passwd!");
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

            // DOTO: Add xyz from db
        }
    }
}
