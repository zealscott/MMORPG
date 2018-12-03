using Common;
using Backend.Game;
using System.Data.Common;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvLogin(IChannel channel, Message message)
        {
            CLogin request = message as CLogin;
            string scene = "Level1";
            Player player = new Player(channel) { scene = scene };

            // read from database
            ConnectDB connect = new ConnectDB();
            int result = connect.LogIn(request.user, request.password, ref player);
            while (result == 0)
            {
                ClientTipInfo(channel, "Wrong UserName or Passwd!");
                result = connect.LogIn(request.user, request.password, ref player);
            }


            SPlayerEnter response = new SPlayerEnter()
            {
                user = request.user,
                token = request.user,
                scene = scene
            };
            channel.Send(response);

            DEntity dentity = World.Instance.EntityData["Ellen"];
            player.FromDEntity(dentity);
            player.forClone = false;
            //ClientTipInfo(channel, "TODO: get player's attribute from database");
            // player will be added to scene when receive client's CEnterSceneDone message
        }
    }
}
