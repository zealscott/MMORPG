using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CPlayerAttribute : Message
    {
        public CPlayerAttribute() : base(Command.C_PLAYER_ATTRIBUTE) { }
        public int intelligence;
        public int speed;
        public int attack;
        public int defense;  
    }
}
