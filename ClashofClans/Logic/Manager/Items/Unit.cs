using Newtonsoft.Json;

namespace ClashofClans.Logic.Manager.Items
{
    public class Unit
    {
        [JsonProperty("cnt")]
        public int Count { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lvl")]
        public int Level { get; set; }

        [JsonProperty("heroId")]
        public int HeroId { get; set; }
    }
}