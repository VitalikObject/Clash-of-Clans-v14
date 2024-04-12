using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Logic.Clan;
using ClashofClans.Protocol.Messages.Server;
using ClashofClans.Protocol.Commands.Server;
using ClashofClans.Logic.Clan.StreamEntry.Entries;
using ClashofClans.Database;

namespace ClashofClans.Protocol.Messages.Client.Alliance
{
    public class LeaveAllianceMessage : PiranhaMessage
    {
        public LeaveAllianceMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.Home;
        }

        public override async void ProcessAsync()
        {
            var home = Device.Player.Home;
            var alliance = await Resources.Alliances.GetAllianceAsync(home.AllianceInfo.Id);
            if (alliance == null) return;

            alliance.Remove(home.Id);
            home.AllianceInfo.Reset();
            Device.Player.Save();

            await new AvailableServerCommandMessage(Device)
            {
                Command = new LogicLeaveAllianceCommand(Device)
                {
                    AllianceId = alliance.Id
                }.Handle()
            }.SendAsync();

            if (alliance.Members.Count != 0)
            {
                /*var entry = new AllianceEventStreamEntry
                {
                    EventType = AllianceEventStreamEntry.Type.Leave
                };

                entry.SetTarget(Device.Player);
                entry.SetSender(Device.Player);
                alliance.AddEntry(entry);

                alliance.Save();*/
            }
            else
            {
                await AllianceDb.DeleteAsync(alliance.Id);
                Resources.ObjectCache.UncacheAlliance(alliance.Id);
            }
        }
    }
}
