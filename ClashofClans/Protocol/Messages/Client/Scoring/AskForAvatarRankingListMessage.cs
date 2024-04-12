using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server.Scoring;

namespace ClashofClans.Protocol.Messages.Client.Scoring
{
    public class AskForAvatarRankingListMessage : PiranhaMessage
    {
        public AskForAvatarRankingListMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public override async void ProcessAsync()
        {
            await new AvatarRankingListMessage(Device).SendAsync();
        }
    }
}
