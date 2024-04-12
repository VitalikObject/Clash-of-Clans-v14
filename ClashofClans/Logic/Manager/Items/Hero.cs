using Newtonsoft.Json;

namespace ClashofClans.Logic.Manager.Items
{
    public class Hero
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lvl")]
        public int Level { get; set; }

        [JsonProperty("skin")]
        public int Skin { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("health")]
        public int Health { get; set; }

        [JsonProperty("mode")]
        public int Mode { get; set; }

        [JsonProperty("petId")]
        public int PetId { get; set; }
    }
}
