using Common;
using System.Collections.Generic;
using Backend.Game;

namespace Backend.Network
{
    public partial class Incoming
    {
        IRegister register;

        //contain on line players info
        public Dictionary<string, Player> OnlinePlayers = new Dictionary<string, Player>();
        // ChatHistory buffer
        public List<string> ChatHistory = new List<string>();
        // treasureInfo
        public Dictionary<string, DTreasure> treasureAttributes = new Dictionary<string, DTreasure>();
        // mall
        public Dictionary<string, DTreasureMall> backMall = new Dictionary<string, DTreasureMall>();

        public Incoming(IRegister register)
        {
            this.register = register;
            RegisterAll();
        }

        private void RegisterAll()
        {
            register.Register(Command.C_LOGIN, OnRecvLogin);
            register.Register(Command.C_REGISTER, OnRecvRegister);
            register.Register(Command.C_PLAYER_ENTER, OnRecvPlayerEnter);
            register.Register(Command.C_PLAYER_MOVE, OnRecvPlayerMove);
            register.Register(Command.C_PLAYER_JUMP, OnRecvPlayerJump);
            register.Register(Command.C_PLAYER_ATTACK, OnRecvPlayerAttack);
            register.Register(Command.C_PLAYER_TAKE, OnRecvPlayerTake);
            register.Register(Command.C_POSITION_REVISE, OnRecvPositionRevise);
            register.Register(Command.C_ENEMY_CLOSING, OnRecvEnemyClosing);
            register.Register(Command.C_DAMAGE, OnRecvDamage);
            register.Register(Command.C_CHAT_MESSAGE, OnRecvChatMessage);

            // DEBUG ..
            register.Register(Command.C_FIND_PATH, OnRecvFindPath);
            register.Register(Command.C_BUY, OnRecvBuy);
            register.Register(Command.C_PLAYER_ATTRIBUTE, OnRecvPlayerAttribute);
            register.Register(Command.C_TREASURE_WEAR, OnRecvTreasureWear);
            register.Register(Command.C_SELL_SILVER, OnRecvSellSilver);
            register.Register(Command.C_SELL_GOLD, OnRecvSellGold);
            register.Register(Command.C_MALL, OnRecvCMall);
            register.Register(Command.C_GETCHATHISTORY, OnRecvGetChatHistory);
            register.Register(Command.C_NOT_SELL, OnRecvNotSell);
            register.Register(Command.C_USE_HP, OnRecvUseHp);
        }


        static void ClientTipInfo(IChannel channel, string info)
        {
            STipInfo tipInfo = new STipInfo();
            tipInfo.info = info;
            channel.Send(tipInfo);
        }





    }
}
