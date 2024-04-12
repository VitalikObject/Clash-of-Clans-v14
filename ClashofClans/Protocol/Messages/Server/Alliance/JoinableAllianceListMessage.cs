using ClashofClans.Logic;
using System.Collections.Generic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Database;
using System;

namespace ClashofClans.Protocol.Messages.Server.Alliance
{
    public class JoinableAllianceListMessage : PiranhaMessage
    {
        public JoinableAllianceListMessage(Device device) : base(device)
        {
            Id = 23429;
        }
        public override async void EncodeAsync()
        {
            var alliances = await AllianceDb.GetRandomAlliancesAsync();

            if (alliances.Count > 0)
            {
                Writer.WriteInt(alliances.Count);

                foreach (var alliance in alliances)
                {
                    alliance.AllianceHeaderEntry(Writer);
                }
            }
            else
            {
                Writer.WriteInt(0);
            }

            Writer.WriteInt(0);
        }
    }
}
