using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Client.Home
{
    public class AskForAvatarProfileMessage : PiranhaMessage
    {
        public AskForAvatarProfileMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public long UserId { get; set; }

        public override void Decode()
        {
            UserId = Reader.ReadLong();
        }

        public override async void ProcessAsync()
        {
            await new AvatarProfileMessage(Device)
            {
                Player = await Resources.Players.GetPlayerAsync(UserId)
            }.SendAsync();
        }
    }
}