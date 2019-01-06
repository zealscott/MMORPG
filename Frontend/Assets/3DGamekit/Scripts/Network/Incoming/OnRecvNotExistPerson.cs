using Common;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvNotExistPerson(IChannel channel, Message message)
        {
            SNotExistPerson msg = message as SNotExistPerson;
            MessageBox.Show(msg.name + " not exist");
        }
    }
}
