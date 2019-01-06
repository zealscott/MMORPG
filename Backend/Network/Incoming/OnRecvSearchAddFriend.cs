using Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvSearchAddFriend(IChannel channel, Message message)
        {
            CSearchAddFriend request = message as CSearchAddFriend;
            string searchName = request.name;
            Player player = (Player)channel.GetContent();
            ConnectDB connect = new ConnectDB();

            int result = connect.SearchFriend(searchName);
            if (result == 0)
            {
                SNotExistPerson msg = new SNotExistPerson() { name = searchName };
                channel.Send(msg);
            }
            else
            {
                connect.AddFriendRequest(player.user, searchName);
            }
        }
    }
}
