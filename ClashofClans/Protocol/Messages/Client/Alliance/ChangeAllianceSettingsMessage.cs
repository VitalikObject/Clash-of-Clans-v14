using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server;
using ClashofClans.Protocol.Commands.Server;
using System.Collections.Generic;

namespace ClashofClans.Protocol.Messages.Client.Alliance
{
    public class ChangeAllianceSettingsMessage : PiranhaMessage
    {
        public ChangeAllianceSettingsMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        private string Description { get; set; }
        private int BadgeId { get; set; }
        private int Type { get; set; }
        private int RequiredScore { get; set; }
        private int RequiredDuelScore { get; set; }
        private int RequiredTownhallLevel { get; set; }
        private int WarFrequency { get; set; }
        private int OriginData { get; set; }
        private int OriginLanguage { get; set; }
        private bool PublicWarLog { get; set; }
        private bool AmicalWarEnabled { get; set; }
        private List<int> ClanLabels = new List<int>();
        public override void Decode()
        {
            Description = Reader.ReadString();
            Reader.ReadString();
            BadgeId = Reader.ReadInt();
            Type = Reader.ReadInt();
            RequiredScore = Reader.ReadInt();
            RequiredDuelScore = Reader.ReadInt();
            RequiredTownhallLevel = Reader.ReadInt();
            WarFrequency = Reader.ReadInt();
            OriginData = Reader.ReadInt();
            OriginLanguage = Reader.ReadInt();
            PublicWarLog = Reader.ReadBoolean();
            AmicalWarEnabled = Reader.ReadBoolean();
            int ClanLabelsCount = Reader.ReadInt();

            for (int i = 0; i < ClanLabelsCount; i++)
            {
                ClanLabels.Add(Reader.ReadInt());
            }
        }

        public override async void ProcessAsync()
        {
            var home = Device.Player.Home;
            var alliance = await Resources.Alliances.GetAllianceAsync(home.AllianceInfo.Id);
            if (alliance == null) return;

            var oldBadge = alliance.Badge;

            alliance.Type = Type;
            alliance.Badge = BadgeId;
            alliance.Description = Description;
            alliance.RequiredScore = RequiredScore;
            alliance.RequiredDuelScore = RequiredDuelScore;
            alliance.WarFrequency = WarFrequency;
            alliance.OriginData = OriginData;
            alliance.PublicWarLog = PublicWarLog;
            alliance.RequiredTownhallLevel = RequiredTownhallLevel;
            alliance.WarFrequency = WarFrequency;
            alliance.OriginData = OriginData;
            alliance.OriginLanguage = OriginLanguage;
            alliance.PublicWarLog = PublicWarLog;
            alliance.AmicalWarEnabled = AmicalWarEnabled;
            alliance.ClanLabels = ClanLabels;

            alliance.Save();

            if (BadgeId == oldBadge)
            {
                await new AvailableServerCommandMessage(Device)
                {
                    Command = new LogicAllianceSettingsChangedCommand(Device)
                    {
                        AllianceId = alliance.Id,
                        AllianceBadge = alliance.Badge
                    }.Handle()
                }.SendAsync();
                return;
            }

            foreach (var member in alliance.Members)
            {
                var player = await member.GetPlayerAsync();
                if (player == null) continue;

                player.Home.AllianceInfo.Badge = BadgeId;
                player.Save();
            }

            await new AvailableServerCommandMessage(Device)
            {
                Command = new LogicAllianceSettingsChangedCommand(Device)
                {
                    AllianceId = alliance.Id,
                    AllianceBadge = alliance.Badge
                }.Handle()
            }.SendAsync();
        }
    }
}