using ClashofClans.Logic;
using ClashofClans.Logic.Clan;
using ClashofClans.Utilities.Netty;
using ClashofClans.Protocol.Messages.Server;
using ClashofClans.Protocol.Commands.Server;
using ClashofClans.Logic.Clan.StreamEntry.Entries;

namespace ClashofClans.Protocol.Messages.Client.Alliance
{
    public class JoinAllianceMessage : PiranhaMessage
    {
        public JoinAllianceMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.Home;
        }

        public long AllianceId { get; set; }

        public override void Decode()
        {
            AllianceId = Reader.ReadLong();
        }

        public override async void ProcessAsync()
        {
            var alliance = await Resources.Alliances.GetAllianceAsync(AllianceId);
            var home = Device.Player.Home;
            if (alliance == null) return;

            /*if (alliance.Members.Count <= 0 || alliance.Members.Count >= 50)
            {
                await new AllianceJoinFailedMessage(Device).SendAsync();
                return;
            }*/

            alliance.Add(new AllianceMember(Device.Player, Logic.Clan.Alliance.Role.Member));

            home.AllianceInfo = alliance.GetAllianceInfo(home.Id);

            await new AvailableServerCommandMessage(Device)
            {
                Command = new LogicJoinAllianceCommand(Device)
                {
                    AllianceId = alliance.Id,
                    AllianceName = alliance.Name,
                    AllianceBadge = alliance.Badge,
                    AllianceExpLevel = alliance.Level
                }.Handle()
            }.SendAsync();

            await new AllianceStreamMessage(Device)
            {
                Entries = alliance.Stream
            }.SendAsync();

            /*var entry = new AllianceEventStreamEntry
            {
                EventType = AllianceEventStreamEntry.Type.Join
            };

            entry.SetTarget(Device.Player);
            entry.SetSender(Device.Player);
            alliance.AddEntry(entry);*/

            alliance.Save();
            Device.Player.Save();
        }
    }
}
