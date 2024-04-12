using Newtonsoft.Json;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Logic.Home.Slots.Items
{
    public class DataSlot
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("cnt")] public int Count { get; set; }

        /// <summary>
        ///     Encodes this dataslot
        /// </summary>
        /// <param name="buffer"></param>
        public virtual void Encode(ByteBuffer buffer)
        {
            buffer.WriteInt(Id);
            buffer.WriteInt(Count);
        }
    }
}