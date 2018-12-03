using Common;
using Backend.Game;
using System;
using System.IO;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvRegister(IChannel channel, Message message)
        {
            CRegister request = message as CRegister;

            ConnectDB connect = new ConnectDB();
            int result = connect.registerUser(request.user,request.password);

            if (result == 0)
                ClientTipInfo(channel, "User Name Exist!");
            else
                ClientTipInfo(channel, "Welcome!");
        }
    }
}
