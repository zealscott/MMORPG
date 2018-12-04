using System;

namespace Common
{
    [Serializable]
    public class SPlayerAttribute : Message
    {
        public SPlayerAttribute() : base(Command.S_PLAYER_ATTRIBUTE) { }

        public int currentHP;
        public int intelligence;
        public int speed;
        public int level;
        public int attack;
        public int defense;
    }
}
