using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using System.Collections.Generic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicRemoveUnitCommand : LogicCommand
    {
        public LogicRemoveUnitCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int UnitsCount { get; set; }
        private List<int> UnitType = new List<int>();
        private List<int> UnitId = new List<int>();
        private List<int> Count = new List<int>();
        public override void Decode()
        {
            UnitsCount = Reader.ReadInt();
            for (int i = 0; i < UnitsCount; i++)
            {
                Reader.ReadInt();
                UnitType.Add(Reader.ReadInt());
                UnitId.Add(Reader.ReadInt());
                Count.Add(Reader.ReadInt());
                Reader.ReadInt();
            }
            Reader.ReadInt();
        }
        public override void Execute()
        {
            for (int i = 0; i < UnitsCount; i++)
            {
                Device.Player.Home.Units.Remove(UnitType[i], UnitId[i], Count[i]);
            }
        }
    }
}