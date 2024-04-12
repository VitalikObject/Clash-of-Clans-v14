using System;
using System.Threading.Tasks;
using ClashofClans.Utilities.Netty;
using Newtonsoft.Json;

namespace ClashofClans.Logic.Clan
{
    public class AllianceMember
    {
        public AllianceMember(Player player, Alliance.Role role)
        {
            Id = player.Home.Id;
            Role = (int) role;
            ExpLevel = player.Home.ExpLevel;
            League = player.Home.League;
            Score = player.Home.Trophies;
            DuelScore = player.Home.DuelTrophies;
            Name = player.Home.Name;
        }

        public AllianceMember()
        {
            // ...
        }

        [JsonProperty("highId")] public int HighId { get; set; }
        [JsonProperty("lowId")] public int LowId { get; set; }
        [JsonProperty("role")] public int Role { get; set; }
        [JsonProperty("expLevel")] public int ExpLevel { get; set; }
        [JsonProperty("league")] public int League { get; set; }
        [JsonProperty("score")] public int Score { get; set; }
        [JsonProperty("duelScore")] public int DuelScore { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("donations")] public int Donations { get; set; }
        [JsonProperty("donationsReceived")] public int DonationsReceived { get; set; }

        [JsonIgnore]
        public long Id
        {
            get => ((long) HighId << 32) | (LowId & 0xFFFFFFFFL);
            set
            {
                HighId = Convert.ToInt32(value >> 32);
                LowId = (int) value;
            }
        }

        [JsonIgnore] public bool IsOnline => Resources.Players.ContainsKey(Id);

        public void AllianceMemberEntry(ByteBuffer packet)
        {
            packet.WriteLong(Id);
            packet.WriteString(Name);
            packet.WriteInt(Role);
            packet.WriteInt(ExpLevel); // exp level
            packet.WriteInt(League); // league type
            packet.WriteInt(Score); // score
            packet.WriteInt(DuelScore); // duel score
            packet.WriteInt(0); // donation count
            packet.WriteInt(0); // received donation count
            packet.WriteInt(0); // order
            packet.WriteInt(0); // previous order 
            packet.WriteInt(0); // order Village2
            packet.WriteInt(0); // previous order Village2
            packet.WriteInt(0); // created time
            packet.WriteInt(0); //war cooldown
            packet.WriteInt(0); //war preference
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            /*packet.WriteInt(Role);
            packet.WriteInt(ExpLevel); // exp level
            packet.WriteInt(League); // league type
            packet.WriteInt(Score); // score
            packet.WriteInt(DuelScore); // duel score
            packet.WriteInt(0); // donation count
            packet.WriteInt(0); // received donation count
            packet.WriteInt(0); //order
            packet.WriteInt(0); //previous order 
            packet.WriteInt(0); //order Village2
            packet.WriteInt(0); //previous order Village2
            packet.WriteInt(0); //created time
            packet.WriteInt(0); //war cooldown
            packet.WriteInt(0); //war preference
            packet.WriteInt(0);
            packet.WriteHex("00000100000000");*/
            /*packet.WriteInt(Role);
            packet.WriteInt(ExpLevel); //exp level
            packet.WriteInt(League); //league type
            packet.WriteInt(Score); //score
            packet.WriteInt(DuelScore); //duel score
            packet.WriteInt(0); //donation count
            packet.WriteInt(0); //received donation count 
            packet.WriteInt(0); //order
            packet.WriteInt(0); //previous order 
            packet.WriteInt(0); //order Village2
            packet.WriteInt(0); //previous order Village2
            packet.WriteInt(0); //created time
            packet.WriteInt(0); //war cooldown
            packet.WriteInt(0); //war preference
            packet.WriteInt(0);*/

            packet.WriteBoolean(true);
            {
                packet.WriteLong(Id);
            }
        }

        public async Task<Player> GetPlayerAsync(bool onlineOnly = false)
        {
            return await Resources.Players.GetPlayerAsync(Id, onlineOnly);
        }
    }
}