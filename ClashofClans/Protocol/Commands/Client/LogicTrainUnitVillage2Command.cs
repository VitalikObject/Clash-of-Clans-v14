using System;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicTrainUnitVillage2Command : LogicCommand
    {
        public LogicTrainUnitVillage2Command(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int UnitId { get; set; }
        public override void Decode()
        {
            Reader.ReadInt();
            Reader.ReadInt();
            UnitId = Reader.ReadInt();
            Reader.ReadInt();
        }
        public override void Execute()
        {
            //Device.Player.Home.Units.TrainTroopV2(UnitId);
        }
    }
}
