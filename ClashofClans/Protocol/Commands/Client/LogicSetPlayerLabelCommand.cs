using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicSetPlayerLabelCommand : LogicCommand
    {
        public LogicSetPlayerLabelCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private List<int> PlayerLabels = new List<int>();
        public override void Decode()
        {
            byte PlayerLabelsCount = Reader.ReadByte();
            for (int i = 0; i < PlayerLabelsCount; i++)
            {
                PlayerLabels.Add(Reader.ReadInt());
            }
            Reader.ReadInt();
        }
        public override void Execute()
        {
            Device.Player.Home.PlayerLabels = PlayerLabels;
        }
    }
}
