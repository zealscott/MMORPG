using Common;
using System;
using System.Threading;


namespace Backend.Network
{
    public partial class Incoming
    {
        public void SyncChatHistory()
        {
            while (true)
            {
                //Thread.Sleep(1);
                Console.WriteLine("sleep 1 ms");
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


