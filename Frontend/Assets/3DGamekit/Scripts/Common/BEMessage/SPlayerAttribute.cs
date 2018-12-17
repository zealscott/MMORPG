using System;

namespace Common
{
    [Serializable]
    public class SPlayerAttribute : Message
    {
        public SPlayerAttribute() : base(Command.S_PLAYER_ATTRIBUTE) { }

        public int playerId;
        public string name;
        public int currentHP;
        public int intelligence;
        public int speed;
        public int level;
        public int attack;
        public int defense;
        public int GoldNum;
        public int SilverNum;
    }
}
