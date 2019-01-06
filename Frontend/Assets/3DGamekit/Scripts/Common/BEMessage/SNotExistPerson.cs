using System;

namespace Common
{
    [Serializable]
    public class SNotExistPerson : Message
    {
        public SNotExistPerson() : base(Command.S_NOT_EXIST_PERSON) { }
        public string name;

    }
}
