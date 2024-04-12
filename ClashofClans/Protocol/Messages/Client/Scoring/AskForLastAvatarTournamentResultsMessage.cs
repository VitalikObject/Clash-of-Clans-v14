using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Protocol.Messages.Server.Scoring;

namespace ClashofClans.Protocol.Messages.Client.Scoring
{
    class AskForLastAvatarTournamentResultsMessage : PiranhaMessage
    {
        public AskForLastAvatarTournamentResultsMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public override async void ProcessAsync()
        {
            await new LastAvatarTournamentResultsMessage(Device).SendAsync();
        }
    }
}
