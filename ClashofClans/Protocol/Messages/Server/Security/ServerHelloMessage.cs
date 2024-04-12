using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using System;

namespace ClashofClans.Protocol.Messages.Server.Security
{
    class ServerHelloMessage : PiranhaMessage
    {
        public ServerHelloMessage(Device device) : base(device)
        {
            Id = 20100;
        }

        public override void EncodeAsync()
        {
            Writer.WriteInt(24);
            Random rnd = new Random();
            for (byte i = 0; i < 24; i++)
            {
                Writer.WriteByte((byte)rnd.Next(0, 255));
            }
        }
    }
}
