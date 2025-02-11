﻿using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server.Scoring;

namespace ClashofClans.Protocol.Messages.Client.Scoring
{
    public class AskForLeagueMemberListMessage : PiranhaMessage
    {
        public AskForLeagueMemberListMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public override async void ProcessAsync()
        {
            await new LeagueMemberListMessage(Device).SendAsync();
        }
    }
}
