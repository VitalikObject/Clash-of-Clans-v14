using System;
using System.Linq;
using System.Text;
using DotNetty.Buffers;
using ClashofClans.Utilities.Compression.ZLib;

namespace ClashofClans.Utilities.Netty
{
    public class ByteBuffer
    {
        private readonly IByteBuffer _buffer;
        private int _bitIdx;
        private int _offset;
        private int _currentByte;

        public int ReadableBytes => _buffer.ReadableBytes;
        public IByteBuffer Buffer => _buffer;

        public ByteBuffer()
        {
            _buffer = Unpooled.Buffer();
        }
        public ByteBuffer(int initialCapacity)
        {
            _buffer = Unpooled.Buffer(initialCapacity);
        }
        public ByteBuffer(IByteBuffer buffer)
        {
            _buffer = buffer;
        }

        public void WriteBoolean(bool value)
        {
            if (_bitIdx == 0)
            {
                _offset = _buffer.WriterIndex;
                _buffer.SetWriterIndex(_offset + 1);
                _buffer.SetByte(_offset, 0);
            }

            int val = _buffer.GetByte(_offset);
            if (value)
            {
                _buffer.SetByte(_offset, val | 1 << _bitIdx);
            }

            _bitIdx = (_bitIdx + 1) & 7;
        }

        public void WriteByte(byte value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteByte(value);
        }

        public void WriteBytes(byte[] value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteBytes(value);
        }

        public void WriteBytes(ByteBuffer value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteBytes(value.Buffer);
        }

        public void WriteShort(short value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteShort(value);
        }

        public void WriteShortLE(short value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteShortLE(value);
        }

        public void WriteUnsignedShort(ushort value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteUnsignedShort(value);
        }

        public void WriteUnsignedShortLE(ushort value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteUnsignedShortLE(value);
        }

        public void WriteMedium(int value)
        {
            _bitIdx= 0;
            _offset = 0;

            _buffer.WriteMedium(value);
        }

        public void WriteMediumLE(int value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteMediumLE(value);
        }

        public void WriteInt(int value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteInt(value);
        }

        public void WriteIntLE(int value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteIntLE(value);
        }

        public void WriteLong(long value)
        {
            _bitIdx = 0;
            _offset = 0;

            _buffer.WriteLong(value);
        }

        public void WriteString(string value)
        {
            _bitIdx = 0;
            _offset = 0;

            if (value == null)
            {
                _buffer.WriteInt(-1);
            }
            else if (value.Length == 0)
            {
                _buffer.WriteInt(0);
            }
            else
            {
                var bytes = Encoding.UTF8.GetBytes(value);

                _buffer.WriteInt(bytes.Length);
                _buffer.WriteString(value, Encoding.UTF8);
            }
        }

        public void WriteVInt(int value)
        {
            _bitIdx = 0;
            _offset = 0;

            var temp = (value >> 25) & 0x40;
            var flipped = value ^ (value >> 31);

            temp |= value & 0x3F;
            value >>= 6;

            if ((flipped >>= 6) == 0)
            {
                _buffer.WriteByte(temp);
                return;
            }

            _buffer.WriteByte(temp | 0x80);

            do
            {
                _buffer.WriteByte((value & 0x7F) | ((flipped >>= 7) != 0 ? 0x80 : 0));
                value >>= 7;
            } while (flipped != 0);
        }

        public void WriteNullVInt(int count = 1)
        {
            _bitIdx = 0;
            _offset = 0;

            for (var i = 0; i < count; i++)
                _buffer.WriteByte(0x7F);
        }

        public void WriteCompressedString(string value, bool indicate = true)
        {
            _bitIdx = 0;
            _offset = 0;

            var data = Encoding.UTF8.GetBytes(value);
            var compressed = ZlibStream.CompressBuffer(data, CompressionLevel.BestCompression);

            if (indicate)
                _buffer.WriteByte(1);

            _buffer.WriteInt(compressed.Length + 4);
            _buffer.WriteIntLE(value.Length);

            _buffer.WriteBytes(compressed);
        }

        public void WriteHex(string value)
        {
            _bitIdx = 0;
            _offset = 0;

            var tmp = value.Replace("-", string.Empty).Replace(" ", string.Empty);
            _buffer.WriteBytes(Enumerable.Range(0, tmp.Length).Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(tmp.Substring(x, 2), 16)).ToArray());
        }

        public void WriteDataReference(int value1, int value2 = 0)
        {
            _bitIdx = 0;
            _offset = 0;

            WriteVInt(value1);

            if (value1 != 0)
            {
                WriteVInt(value2);
            }
        }

        public void WriteLogicLong(int value1, int value2)
        {
            _bitIdx = 0;
            _offset = 0;

            WriteVInt(value1);
            WriteVInt(value2);
        }

        public void WriteConstantSizeIntArray()
        {
            _bitIdx = 0;
            _offset = 0;

            for (int i = 0; i < 8; i++)
            {
                WriteVInt(0);
            }
        }

        public bool ReadBoolean()
        {
            if (_bitIdx == 0)
            {
                _currentByte = _buffer.ReadByte() & 0xFF;
            }

            bool value = (_currentByte & 1 << _bitIdx) != 0;
            _bitIdx = (_bitIdx + 1) & 7;
            return value;
        }

        public byte ReadByte()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadByte();
        }

        public IByteBuffer ReadBytes(int length)
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadBytes(length);
        }

        public short ReadShort()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadShort();
        }

        public short ReadShortLE()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadShortLE();
        }

        public ushort ReadUnsignedShort()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadUnsignedShort();
        }

        public ushort ReadUnsignedShortLE()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadUnsignedShortLE();
        }

        public int ReadMedium()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadMedium();
        }

        public int ReadMediumLE()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadMediumLE();
        }

        public int ReadInt()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadInt();
        }

        public uint ReadUnsignedInt()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadUnsignedInt();
        }

        public int ReadIntLE()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadIntLE();
        }

        public long ReadLong()
        {
            _bitIdx = 0;
            _currentByte = 0;

            return _buffer.ReadLong();
        }

        public string ReadString()
        {
            _bitIdx = 0;
            _currentByte = 0;

            var length = _buffer.ReadInt();

            if (length <= 0 || length > 900000)
                return string.Empty;

            return _buffer.ReadString(length, Encoding.UTF8);
        }

        public string ReadCompressedString(bool indicator = true)
        {
            _bitIdx = 0;
            _currentByte = 0;

            if (indicator)
                _buffer.ReadByte();

            var compressedLength = _buffer.ReadInt() - 4;
            _buffer.ReadIntLE();

            var compressedBytes = _buffer.ReadBytes(compressedLength);

            return ZlibStream.UncompressString(compressedBytes.Array);
        }

        public int ReadVInt()
        {
            _bitIdx = 0;
            _currentByte = 0;

            int b, sign = ((b = _buffer.ReadByte()) >> 6) & 1, i = b & 0x3F, offset = 6;

            for (var j = 0; j < 4 && (b & 0x80) != 0; j++, offset += 7)
                i |= ((b = _buffer.ReadByte()) & 0x7F) << offset;

            return (b & 0x80) != 0 ? -1 : i | (sign == 1 && offset < 32 ? i | (int)(0xFFFFFFFF << offset) : i);
        }

        public void SetReaderIndex(int index)
        {
            _buffer.SetReaderIndex(index);
        }

        public byte GetByte(int index)
        {
            return _buffer.GetByte(index);
        }

        public void SetByte(int index, int value)
        {
            _buffer.SetByte(index, value);
        }
    }
}
