using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Server
{
    public class AvatarProfileMessage : PiranhaMessage
    {
        public AvatarProfileMessage(Device device) : base(device)
        {
            Id = 26443;
        }

        public Player Player { get; set; }

        public override void EncodeAsync()
        {
            if (Player == null)
                return;

            Player.LogicClientAvatar(Writer);

            Writer.WriteCompressedString(Player.Home.GameObjectManager.Save(), false);

            Writer.WriteInt(0);
            Writer.WriteInt(0);
            Writer.WriteInt(0);
            Writer.WriteInt(0);

            Writer.WriteBoolean(false);
            Writer.WriteInt(0);
         }
    }
}