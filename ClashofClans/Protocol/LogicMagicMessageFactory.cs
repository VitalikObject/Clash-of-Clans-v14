using System;
using System.Collections.Generic;
using ClashofClans.Protocol.Messages.Client;
using ClashofClans.Protocol.Messages.Client.Chat;
using ClashofClans.Protocol.Messages.Client.Home;
using ClashofClans.Protocol.Messages.Client.Scoring;
using ClashofClans.Protocol.Messages.Client.Account;
using ClashofClans.Protocol.Messages.Client.Alliance;
using ClashofClans.Protocol.Messages.Client.Security;

namespace ClashofClans.Protocol
{
    public class LogicMagicMessageFactory
    {
        public static Dictionary<int, Type> Messages;

        static LogicMagicMessageFactory()
        {
            Messages = new Dictionary<int, Type>
            {
                {10100, typeof(ClientHelloMessage)},
                {10101, typeof(LoginMessage)},
                {10108, typeof(KeepAliveMessage)},
                {10601, typeof(SendGlobalChatLineMessage)},
                {10936, typeof(GoHomeMessage)},
                {11186, typeof(AskForAllianceDataMessage)},
                {11206, typeof(ChangeAllianceSettingsMessage)},
                {11734, typeof(AskForAvatarProfileMessage)},
                {12461, typeof(AskForLastAvatarTournamentResultsMessage)},
                {12733, typeof(JoinAllianceMessage)},
                {12865, typeof(AskForAllianceRankingListMessage)},
                {12906, typeof(EndClientTurnMessage)},
                {13316, typeof(SearchAlliancesMessage)},
                {13439, typeof(LeaveAllianceMessage)},
                {13586, typeof(AskForLeagueMemberListMessage)},
                {13677, typeof(HomeBattleReplayMessage)},
                {13708, typeof(SetDeviceTokenMessage)},
                {13723, typeof(AskForAvatarLocalRankingListMessage)},
                {14322, typeof(VisitHomeMessage)},
                {14359, typeof(AskForAvatarRankingListMessage)},
                {14466, typeof(ChatToAllianceStreamMessage)},
                {15027, typeof(AskForJoinableAlliancesListMessage)},
                {15718, typeof(AttackNpcMessage)},
                {16203, typeof(AnalyticEventMessage)},
                {17173, typeof(ChangeAvatarNameMessage)},
                {19044, typeof(CreateAllianceMessage)},
                {19756, typeof(AskForJWTTokenMessage)},
                {30000, typeof(AttributionMessage)}
            };
        }
    }
}