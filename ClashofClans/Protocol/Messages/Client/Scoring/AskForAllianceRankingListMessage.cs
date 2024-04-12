using System;
using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Protocol.Messages.Server.Scoring;

namespace ClashofClans.Protocol.Messages.Client.Scoring
{
    public class AskForAllianceRankingListMessage : PiranhaMessage
    {
        public AskForAllianceRankingListMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public bool LocalRanking { get; set; }

        public override void Decode()
        {
            if (Reader.ReadBoolean())
            {
                Reader.ReadLong();
            }
            LocalRanking = Reader.ReadBoolean();
        }
        public override async void ProcessAsync()
        {
            if (LocalRanking)
                await new AllianceLocalRankingListMessage(Device).SendAsync();
            else
                await new AllianceRankingListMessage(Device).SendAsync();
        }
    }
}
