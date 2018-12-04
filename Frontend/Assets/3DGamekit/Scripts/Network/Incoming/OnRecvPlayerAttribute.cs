using Common;
using System;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvPlayerAttribute(IChannel channel, Message message)
        {
            SPlayerAttribute msg = message as SPlayerAttribute;
            //NetworkEntity player = networkEntities[msg.playerID];
            //Player m_player = player.gameObject.GetComponent<Player>();
            //if (m_player == null)
            //    return;

            Player.currentHP = msg.currentHP;
            Player.level = msg.level;
            Player.speed = msg.speed;
            Player.defense = msg.defense;
            Player.attack = msg.attack;
            Player.intelligence = msg.intelligence;

            //MessageBox.Show("Updated player attributes.");
            MessageBox.Show(string.Format("receive speed {0}", Player.speed));
        }
    }
}
