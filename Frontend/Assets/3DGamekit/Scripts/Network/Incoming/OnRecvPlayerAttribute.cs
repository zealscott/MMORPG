using Common;
using System;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvPlayerAttribute(IChannel channel, Message message)
        {
            SPlayerAttribute msg = message as SPlayerAttribute;

            PlayerInfo.playerId = msg.playerId;
            PlayerInfo.name = msg.name;
            PlayerInfo.currentHP = msg.currentHP;
            PlayerInfo.level = msg.level;
            PlayerInfo.speed = msg.speed;
            PlayerInfo.defense = msg.defense;
            PlayerInfo.attack = msg.attack;
            PlayerInfo.intelligence = msg.intelligence;
            PlayerInfo.GoldNum = msg.GoldNum;
            PlayerInfo.SilverNum = msg.SilverNum;

            //MessageBox.Show("Updated player attributes.");
            MessageBox.Show(string.Format("receive speed {0}", PlayerInfo.speed));
        }
    }
}
