﻿using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicNewTownHallReachedBoostCommand : LogicCommand
    {
        public LogicNewTownHallReachedBoostCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt();
        }
    }
}