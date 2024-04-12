using System;
using System.Linq;
using Newtonsoft.Json;
using ClashofClans.Utilities.Netty;
using System.Diagnostics;
using ClashofClans.Database;
using System.Collections.Generic;
using ClashofClans.Logic.Clan.StreamEntry;
using ClashofClans.Protocol.Messages.Server.Alliance;

namespace ClashofClans.Logic.Clan
{
    public class Alliance
    {
        public enum Role
        {
            Member = 1,
            Leader = 2,
            Elder = 3,
            CoLeader = 4
        }

        [JsonProperty("members")] public List<AllianceMember> Members = new List<AllianceMember>(50);
        [JsonProperty("stream")] public List<AllianceStreamEntry> Stream = new List<AllianceStreamEntry>(40);

        public Alliance(long id)
        {
            Id = id;
            Name = "Clash";
        }

        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("highId")] public int HighId { get; set; }
        [JsonProperty("lowId")] public int LowId { get; set; }
        [JsonProperty("badge")] public int Badge { get; set; }
        [JsonProperty("region")] public int Region { get; set; }
        [JsonProperty("level")] public int Level { get; set; }
        [JsonProperty("type")] public int Type { get; set; }
        [JsonProperty("requiredScore")] public int RequiredScore { get; set; }
        [JsonProperty("requiredDuelScore")] public int RequiredDuelScore { get; set; }
        [JsonProperty("requiredTownhallLevel")] public int RequiredTownhallLevel { get; set; }
        [JsonProperty("warFrequency")] public int WarFrequency { get; set; }
        [JsonProperty("originData")] public int OriginData { get; set; }
        [JsonProperty("originLanguage")] public int OriginLanguage { get; set; }
        [JsonProperty("publicWarLog")] public bool PublicWarLog { get; set; }
        [JsonProperty("amicalWarEnabled")] public bool AmicalWarEnabled { get; set; }
        [JsonProperty("clanLabels")] public List<int> ClanLabels = new List<int>();

        [JsonIgnore] public int Score => Members.Sum(m => m.Score) / 2;

        [JsonIgnore] public int DuelScore => Members.Sum(m => m.DuelScore) / 2;

        [JsonIgnore] public int Online => Members.Count(m => m.IsOnline);

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

        public void AllianceRankingEntry(ByteBuffer packet, int order)
        {
            RankingEntry(packet, order);

            packet.WriteInt(Badge);
            packet.WriteInt(Members.Count);

            packet.WriteInt(0);

            packet.WriteInt(Level);
        }

        public void RankingEntry(ByteBuffer packet, int order)
        {
            packet.WriteLong(Id);
            packet.WriteString(Name);
            packet.WriteInt(order);
            packet.WriteInt(Score);
            packet.WriteInt(0);
        }

        public void AllianceFullEntry(ByteBuffer packet)
        {
            AllianceHeaderEntry(packet);

            packet.WriteString(Description);
        }

        public void AllianceHeaderEntry(ByteBuffer packet)
        {
            packet.WriteLong(Id);
            packet.WriteString(Name);
            packet.WriteInt(Badge);
            packet.WriteInt(Type);
            packet.WriteInt(Members.Count);
            packet.WriteInt(Score);
            packet.WriteInt(DuelScore);
            packet.WriteInt(RequiredScore);
            packet.WriteInt(RequiredDuelScore);
            packet.WriteInt(RequiredTownhallLevel);
            packet.WriteInt(0); // lost war count
            packet.WriteInt(0); // draw war count

            packet.WriteInt(1); // locale data

            packet.WriteInt(WarFrequency); // war frequency

            packet.WriteInt(OriginLanguage);

            packet.WriteInt(1);

            packet.WriteInt(OriginData); // country 32000000
            packet.WriteInt(0); // exp points 
            packet.WriteInt(1); // clan level
            packet.WriteInt(0); // consecutive win war count
            packet.WriteBoolean(PublicWarLog);
            packet.WriteInt(0);
            packet.WriteBoolean(AmicalWarEnabled); // amical wars enabled

            packet.WriteInt(11); // clan league?
            
            packet.WriteInt(ClanLabels.Count);

            foreach (var label in ClanLabels)
            {
                packet.WriteInt(label);
            }
            //packet.WriteHex("00 00 00 03   03 56 7e 00   03 56 7e 01  03 56 7e 0e");
            /*packet.WriteInt(Badge);
            packet.WriteInt(Type);
            packet.WriteInt(Members.Count);
            packet.WriteInt(Score);
            packet.WriteInt(DuelScore); //duel score
            packet.WriteInt(RequiredScore);
            packet.WriteInt(RequiredDuelScore); //required duel score
            packet.WriteInt(0); //win war count
            packet.WriteInt(0); //lost war count
            packet.WriteInt(0); //draw war count

            packet.WriteInt(0); //locale data

            packet.WriteInt(WarFrequency); //war frequency

            packet.WriteInt(OriginData); //origin data

            packet.WriteInt(0); //exp point
            packet.WriteInt(Level); //exp level
            packet.WriteInt(0); //consecutive win war count
            packet.WriteBoolean(PublicWarLog); //public war log
            packet.WriteInt(0);
            packet.WriteBoolean(AmicalWarEnabled); //amical war enabled
            packet.WriteInt(0);*/
        }

        public AllianceInfo GetAllianceInfo(long userId)
        {
            return new AllianceInfo
            {
                Id = Id,
                Name = Name,
                Badge = Badge,
                Role = GetRole(userId),
                Level = Level
            };
        }

        public void Add(AllianceMember member)
        {
            lock (Members)
            {
                var index = Members.FindIndex(x => x.Id == member.Id);

                if (index == -1) Members.Add(member);
            }
        }

        public async void Remove(long id)
        {
            var index = Members.FindIndex(x => x.Id == id);

            if (index > -1)
            {
                var member = Members[index];

                // If the leader leaves the clan and it's not empty, we choose a new leader 
                if (member.Role == (int) Role.Leader)
                {
                    var newLeader = Members.FirstOrDefault(m => m.Id != member.Id);
                    if (newLeader != null)
                    {
                        var player = await newLeader.GetPlayerAsync();

                        newLeader.Role = (int) Role.Leader;
                        player.Home.AllianceInfo.Role = (int) Role.Leader;

                        player.Save();
                    }
                }

                lock (Members)
                {
                    Members.RemoveAt(index);
                }
            }
        }

        public async void AddEntry(AllianceStreamEntry entry)
        {
            lock (Stream)
            {
                while (Stream.Count >= 40)
                    Stream.RemoveAt(0);

                var max = Stream.Count == 0 ? 1 : Stream.Max(x => x.Id);
                entry.Id = max == int.MaxValue ? 1 : max + 1; // If we ever reach that value... but who knows...

                Stream.Add(entry);
            }

            foreach (var member in Members.Where(m => m.IsOnline).ToList())
            {
                var player = await member.GetPlayerAsync(true);

                if (player != null)
                    await new AllianceStreamEntryMessage(player.Device)
                    {
                        Entry = entry
                    }.SendAsync();
            }
        }

        /*public async void RemoveEntry(AllianceStreamEntry entry)
        {
            lock (Stream)
            {
                Stream.RemoveAll(e => e.Id == entry.Id);
            }

            foreach (var member in Members.Where(m => m.IsOnline).ToList())
            {
                var player = await member.GetPlayerAsync(true);

                if (player != null)
                    await new AllianceStreamEntryRemovedMessage(player.Device)
                    {
                        EntryId = entry.Id
                    }.SendAsync();
            }
        }*/

        public int GetRole(long id)
        {
            lock (Members)
            {
                var index = Members.FindIndex(x => x.Id == id);

                return index > -1 ? Members[index].Role : 1;
            }
        }

        public AllianceMember GetMember(long id)
        {
            lock (Members)
            {
                var index = Members.FindIndex(x => x.Id == id);

                return index > -1 ? Members[index] : null;
            }
        }

        /*public async void UpdateOnlineCount()
        {
            var count = Online;

            foreach (var member in Members.Where(m => m.IsOnline).ToList())
            {
                var player = await Resources.Players.GetPlayerAsync(member.Id, true);

                if (player != null)
                    await new AllianceOnlineStatusUpdatedMessage(player.Device)
                    {
                        Count = count
                    }.SendAsync();
            }
        }*/

        public async void Save()
        {
#if DEBUG
            var st = new Stopwatch();
            st.Start();

            //await Redis.CacheAsync(this);
            await AllianceDb.SaveAsync(this);

            st.Stop();
            Logger.Log($"Alliance {Id} saved in {st.ElapsedMilliseconds}ms.", GetType(), Logger.ErrorLevel.Debug);
#else
            //await Redis.CacheAsync(this);
            await AllianceDb.SaveAsync(this);
#endif
        }
    }
}