using Common;
using System;
using System.Threading;


namespace Backend.Network
{
    public partial class Incoming
    {
        public void SyncChatHistory(object Internal)
        {
            while (true)
            {
                Thread.Sleep((int)Internal);
                //Console.WriteLine("sleep 1 s");
                if (ChatHistory.Count > 0)
                {
                    Console.WriteLine("clean chat log");
                    ConnectDB connect = new ConnectDB();
                    connect.DBSyncChat(ChatHistory);
                    ChatHistory.Clear();
                }
            }
        }
    }
}


