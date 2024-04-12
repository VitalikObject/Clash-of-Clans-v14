using ClashofClans.Files.CsvHelpers;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Extensions
{
    /// <summary>
    ///     This implements a few extensions for games from supercell
    /// </summary>
    public static class CustomWriter
    {
        /// <summary>
        ///     Encodes CsvData
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="value"></param>
        public static void WriteData(this ByteBuffer buffer, Data value)
        {
            buffer.WriteInt(value.GetDataType());
            buffer.WriteInt(value.GetInstanceId());
        }
    }
}