using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Database;
using System;
using ClashofClans.Logic.Clan;
using ClashofClans.Protocol.Commands.Server;
using ClashofClans.Protocol.Messages.Server;
using System.Collections.Generic;

namespace ClashofClans.Protocol.Messages.Client.Alliance
{
    public class CreateAllianceMessage : PiranhaMessage
    {
        public CreateAllianceMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.Home;
        }
        private string AllianceName { get; set; }
        private string AllianceDescription { get; set; }
        private int AllianceBadgeId { get; set; }
        private int AllianceType { get; set; }
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
            AllianceName = Reader.ReadString();
            AllianceDescription = Reader.ReadString();
            AllianceBadgeId = Reader.ReadInt();
            AllianceType = Reader.ReadInt();
            RequiredScore = Reader.ReadInt();
            RequiredDuelScore = Reader.ReadInt();
            RequiredTownhallLevel = Reader.ReadInt();
            WarFrequency = Reader.ReadInt();
            OriginData = Reader.ReadInt();
            OriginLanguage = Reader.ReadInt();
            PublicWarLog = Reader.ReadBoolean();
            AmicalWarEnabled = Reader.ReadBoolean();
            byte ClanLabelsCount = Reader.ReadByte();

            for (int i = 0; i < ClanLabelsCount; i++)
            {
                ClanLabels.Add(Reader.ReadInt());
            }
        }
        public override async void ProcessAsync()
        {
            var player = Device.Player;

            var alliance = await AllianceDb.CreateAsync();
       
            if (alliance != null)
            {
                alliance.Name = AllianceName;
                alliance.Description = AllianceDescription;
                alliance.Badge = AllianceBadgeId;
                alliance.Type = AllianceType;
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
                alliance.Level = 1;

                alliance.Members.Add(
                    new AllianceMember(player, Logic.Clan.Alliance.Role.Leader));

                player.Home.AllianceInfo = alliance.GetAllianceInfo(player.Home.Id);

                player.Save();

                alliance.Save();

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

                await new AvailableServerCommandMessage(Device)
                {
                    Command = new LogicChangeAllianceRoleCommand(Device)
                    {
                        AllianceId = alliance.Id,
                        AllianceRole = 2
                    }.Handle()
                }.SendAsync();
            } else
            {
                Device.Disconnect();
            }
        }
    }
}
