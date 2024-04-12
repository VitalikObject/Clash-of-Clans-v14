using System;
using ClashofClans.Utilities.Netty;
using DotNetty.Buffers;

namespace ClashofClans.Analyzer
{
    public class Program
    {
        public static void Main()
        {
            var hex = "0000008b955f0a04000000030000025b0000000100000000000002150000000500000021000000141dcd650600000021000000121dcd650700000021000000161dcd650800000021000000131dcd650900000021000000151dcd650a00000039000002150000000500000021000000141dcd650600000021000000121dcd650700000021000000161dcd650800000021000000131dcd650900000021000000151dcd650a0000004b";
            hex = hex.Replace(" ", string.Empty);

            var buffer = Unpooled.Buffer();
            //buffer.WriteHex(hex);

            buffer.SetReaderIndex(0);

            //DecodeHeader(buffer);

            for(var i = 0; i < 42; i++)
                Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            //DecodeLogicClientHome(buffer);
            //DecodeLogicClientAvatar(buffer);
            //Console.WriteLine(buffer.ReadCompressedString(false));

            buffer.DiscardReadBytes();
            Console.WriteLine(BitConverter.ToString(buffer.ReadBytes(buffer.ReadableBytes).Array).Replace("-", string.Empty));

            Console.Read();
        }

        public static void DecodeHeader(ByteBuffer buffer)
        {
            Console.WriteLine("--HEADER--");
            Console.WriteLine($"ID:      {buffer.ReadShort()}");
            Console.WriteLine($"Length:  {buffer.ReadMedium()}");
            Console.WriteLine($"Version: {buffer.ReadShort()}");
            Console.WriteLine("--HEADER END--");
        }

        public static void DecodeLogicClientAvatar(ByteBuffer buffer)
        {
            Console.WriteLine(buffer.ReadLong());
            Console.WriteLine(buffer.ReadLong());

            Console.WriteLine(buffer.ReadByte()); // HasAlliance

            Console.WriteLine("--ALLIANCE--");
            Console.WriteLine(buffer.ReadLong());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt()); // Badge
            Console.WriteLine(buffer.ReadInt()); // Members
            Console.WriteLine(buffer.ReadInt()); // Members

            Console.WriteLine(buffer.ReadByte());
            Console.WriteLine(buffer.ReadLong());
            Console.WriteLine("--ALLIANCE END--");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            Console.WriteLine(buffer.ReadString());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt()); // Exp Level
            Console.WriteLine(buffer.ReadInt()); // Exp Points

            Console.WriteLine(buffer.ReadInt()); // Diamonds
            Console.WriteLine(buffer.ReadInt()); // Diamonds

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadInt()); // Trophies
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadInt()); // Clan Castle Gold
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadByte());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadByte());

            var recourceCapCount = buffer.ReadInt();
            for (var i = 0; i < recourceCapCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var resourceCount = buffer.ReadInt();
            for (var i = 0; i < resourceCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var troopCount = buffer.ReadInt();
            for (var i = 0; i < troopCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var spellCount = buffer.ReadInt();
            for (var i = 0; i < spellCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var troopLevelCount = buffer.ReadInt();
            for (var i = 0; i < troopLevelCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var spellLevelCount = buffer.ReadInt();
            for (var i = 0; i < spellLevelCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var heroLevelCount = buffer.ReadInt();
            for (var i = 0; i < heroLevelCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var heroHealthCount = buffer.ReadInt();
            for (var i = 0; i < heroHealthCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var heroStateCount = buffer.ReadInt();
            for (var i = 0; i < heroStateCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            Console.WriteLine($"ClanUnits: {buffer.ReadInt()}");

            var unknownCount = buffer.ReadInt();
            for (var i = 0; i < unknownCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            Console.WriteLine(buffer.ReadInt());

            var missionCount = buffer.ReadInt();
            for (var i = 0; i < missionCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
            }

            var achivementCount = buffer.ReadInt();
            for (var i = 0; i < achivementCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            var completedAchivementCount = buffer.ReadInt();
            for (var i = 0; i < completedAchivementCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            Console.WriteLine(buffer.ReadInt());

            var npcCount = buffer.ReadInt();
            for (var i = 0; i < npcCount; i++)
            {
                Console.WriteLine(buffer.ReadInt());
                Console.WriteLine(buffer.ReadInt());
            }

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");

            for (var i = 0; i < 97; i++)
            {
                Console.WriteLine($"packet.WriteInt({buffer.ReadInt()});");
            }

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadByte());
        }

        public static void DecodeLogicClientHome(ByteBuffer buffer)
        {
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadLong());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt()); // 14400

            Console.WriteLine(buffer.ReadCompressedString());
            Console.WriteLine(buffer.ReadCompressedString());
            Console.WriteLine(buffer.ReadCompressedString());
        }

        public static void DecodeLoginOk(ByteBuffer buffer)
        {
            Console.WriteLine(buffer.ReadLong());
            Console.WriteLine(buffer.ReadLong());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadString());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadString());
            Console.WriteLine(buffer.ReadString());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadString());
            Console.WriteLine(buffer.ReadString());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt());

            Console.WriteLine(buffer.ReadString());
            Console.WriteLine(buffer.ReadString());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt());
            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadByte());
            Console.WriteLine(buffer.ReadByte());

            Console.WriteLine(buffer.ReadString());

            Console.WriteLine(buffer.ReadInt());
        }
    }
}
