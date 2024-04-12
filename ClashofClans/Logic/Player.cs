using System;
using Newtonsoft.Json;
using ClashofClans.Utilities.Netty;
using ClashofClans.Files;
using ClashofClans.Database;
using ClashofClans.Files.CsvUtils;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Logic
{
    public class Player
    {
        public Player(long id)
        {
            Home = new Home.Home(id, GameUtils.GenerateToken);
        }

        public Player()
        {
            // Player.
        }

        public Home.Home Home { get; set; }

        [JsonIgnore] public Device Device { get; set; }

        public void LogicClientHome(ByteBuffer packet)
        {
            // Home Id
            packet.WriteLong(Home.Id);

            packet.WriteInt(0); // Shield
            packet.WriteInt(0); // Protection

            packet.WriteInt(0);
            packet.WriteCompressedString(Home.GameObjectManager.Save());

            packet.WriteCompressedString(Levels.Calendar);
            packet.WriteCompressedString(Levels.Globals);
        }

        public void LogicClientAvatar(ByteBuffer packet)
        {
            if (Home.CurrentSeasonMonth != DateTime.Now.Month)
            {
                Home.PreviousSeasonTrophies = Home.Trophies;
                Home.PreviousSeasonMonth = DateTime.Now.Month - 1;
                Home.CurrentSeasonMonth = DateTime.Now.Month;

                if (Home.Trophies >= 5000)
                    Home.Trophies = 5000;

                Home.League = 0;
                Home.AttacksWon = 0;
                Home.DefensesWon = 0;
            }

            packet.WriteLong(Home.Id);

            // Home Id
            packet.WriteLong(Home.Id);

            var info = Home.AllianceInfo;

            if (info.HasAlliance)
            {
                packet.WriteBoolean(true);
                {
                    packet.WriteLong(info.Id);
                    packet.WriteString(info.Name);
                    packet.WriteInt(info.Badge);
                    packet.WriteInt(info.Role);
                    packet.WriteInt(info.Level);
                }
            }
            else
            {
                packet.WriteBoolean(false);
            }

            packet.WriteBoolean(Home.League != 0);
            if (Home.League != 0)
                packet.WriteLong(Home.League);

            packet.WriteInt(0);
            packet.WriteInt(1);

            //sub_78D76
            packet.WriteInt(0);
            packet.WriteInt(1000);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);

            //sub_78D76
            packet.WriteInt(0);
            packet.WriteInt(1000);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);

            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(Home.League);

            packet.WriteByte(0);
            packet.WriteByte(0);
            packet.WriteByte(0);
            packet.WriteByte(0);
            packet.WriteByte(0);
            packet.WriteByte(0);
            packet.WriteByte(0);
            packet.WriteByte((byte)Home.GameObjectManager.GetTownhallLevel());
            packet.WriteByte(0);
            packet.WriteByte(0);
            packet.WriteByte(0);
            packet.WriteByte(0);

            packet.WriteString(Home.Name);
            packet.WriteString(null);

            packet.WriteInt(Home.ExpLevel); // Level
            packet.WriteInt(Home.ExpPoints); // Exp

            packet.WriteInt(Home.Diamonds);
            packet.WriteInt(Home.Diamonds);

            packet.WriteInt(1200);
            packet.WriteInt(60);
            packet.WriteInt(Home.Trophies);
            packet.WriteInt(Home.DuelTrophies);
            packet.WriteInt(Home.AttacksWon); //attacks won
            packet.WriteInt(0);
            packet.WriteInt(Home.DefensesWon); //defenses won
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0); //Home.League == 22 ? 1 : 0

            packet.WriteBoolean(false);
            packet.WriteBoolean(false);
            packet.WriteBoolean(false);

            packet.WriteInt(-1);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);

            packet.WriteBoolean(false);
            packet.WriteBoolean(false);

            packet.WriteInt(0);
            Home.Resources.Encode(packet); //resource slot data

            //combat item slot data
            packet.WriteInt(Home.Units.Troops.Count); // Home Troops
            foreach (var troop in Home.Units.Troops)
            {
                packet.WriteInt(troop.Id);
                packet.WriteInt(troop.Count);
            }

            packet.WriteInt(Home.Units.Troops.Count); // Home Troop Levels
            foreach (var troop in Home.Units.Troops)
            {
                packet.WriteInt(troop.Id);
                packet.WriteInt(troop.Level);
            }

            packet.WriteInt(Home.Units.Spells.Count);
            foreach (var spell in Home.Units.Spells)
            {
                packet.WriteInt(spell.Id);
                packet.WriteInt(spell.Count);
            }

            packet.WriteInt(Home.Units.Spells.Count); // Spell Levels
            foreach (var spell in Home.Units.Spells)
            {
                packet.WriteInt(spell.Id);
                packet.WriteInt(spell.Level);
            }

            packet.WriteInt(Home.Characters.Heroes.Count);
            foreach (var hero in Home.Characters.Heroes)
            {
                packet.WriteInt(hero.Id);
                packet.WriteInt(hero.Level);
            }

            packet.WriteInt(Home.Units.SiegeMachines.Count);
            foreach (var machine in Home.Units.SiegeMachines)
            {
                packet.WriteInt(machine.Id);
                packet.WriteInt(machine.Count);
            }

            packet.WriteInt(Home.Units.SiegeMachines.Count); // siege machine lvl
            foreach (var machine in Home.Units.SiegeMachines)
            {
                packet.WriteInt(machine.Id);
                packet.WriteInt(machine.Level);
            }

            packet.WriteInt(Home.Units.Pets.Count);
            foreach (var pet in Home.Units.Pets)
            {
                packet.WriteInt(pet.Id);
                packet.WriteInt(pet.Level);
            }
            //combat item slot data

            packet.WriteInt(Home.Characters.Heroes.Count); //hero health slot data
            foreach (var hero in Home.Characters.Heroes)
            {
                packet.WriteInt(hero.Id);
                packet.WriteInt(hero.Health);
            }
            packet.WriteInt(Home.Characters.Heroes.Count); //hero state slot data
            foreach (var hero in Home.Characters.Heroes)
            {
                packet.WriteInt(hero.Id);
                packet.WriteInt(3);
            }
            packet.WriteInt(0); //alliance unit data

            var mission = Home.NameSet == 0 ? 10 : 150;
            packet.WriteInt(mission);
            for (var i = 0; i < mission; i++)
                packet.WriteInt(21000000 + i);

            packet.WriteInt(0); //achievement progress data
            packet.WriteInt(0);

            packet.WriteInt(96); //npc map proress data
            for (var i = 0; i < 96; i++)
            {
                packet.WriteInt(17000000 + i);
                packet.WriteInt(3);
            }

            packet.WriteInt(0); //npc looted gold data
            packet.WriteInt(0); //npc looted elixir data
            packet.WriteInt(0); //npc looted dark elixir data
            packet.WriteInt(0); //deploy step disable data

            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(0);

            packet.WriteInt(Home.Characters.Heroes.Count); //hero mode slot data
            foreach (var hero in Home.Characters.Heroes)
            {
                packet.WriteInt(hero.Id);
                packet.WriteInt(hero.Mode);
            }
            packet.WriteInt(44);
            {
                packet.WriteInt(0); // StarBonusCounter
                packet.WriteInt(0); // StarBonusCooldown
                packet.WriteInt(0); // StarBonusTimerEndSubTick
                packet.WriteInt(0); // StarBonusTimerEndTimestep
                packet.WriteInt(0); // StarBonusTimesCollected

                packet.WriteInt(0); // ChallengeStarted
                packet.WriteInt(0); // ChallengeLayoutIsWar

                packet.WriteInt(0); // FriendListLastOpened
                packet.WriteInt(0); // BeenInArrangedWar
                packet.WriteInt(0); // UNUSED_WITH_OLD_VALUE
                packet.WriteInt(0); // AccountBound
                packet.WriteInt(0); // EventUseTroop

                packet.WriteInt(Home.State); // VillageToGoTo

                packet.WriteInt(0); // LootLimitWinCount
                packet.WriteInt(0); // LootLimitTimerEndSubTick
                packet.WriteInt(0); // LootLimitTimerEndTimestamp
                packet.WriteInt(0); // LootLimitCooldown

                packet.WriteInt(0); // Village2BarrackLevel
                packet.WriteInt(0); // LootLimitFreeSpeedUp
                packet.WriteInt(1); // SeenBuilderMenu

                packet.WriteInt(0); // MaxArmyTimerEndSubTick
                packet.WriteInt(0); // MaxArmyTimerEndTimeStamp
                packet.WriteInt(0); // MaxArmyTimerPausedTicksLeft

                packet.WriteInt(0); // AllianceUnitDeploymentMethod
                packet.WriteInt(1); // ShowOnlyRelevantTroopRequests

                packet.WriteInt(0); // HeroPotionTimerEndSubTick
                packet.WriteInt(0); // HeroPotionTimerEndTimeStamp
                packet.WriteInt(0); // HeroPotionTimerPausedTicksLeft

                packet.WriteInt(0); // TaskEventProgress1
                packet.WriteInt(0); // TaskEventProgress2
                packet.WriteInt(0); // TaskEventProgress3

                packet.WriteInt(0); // ClanChatRulesVersion
                packet.WriteInt(0); // ClanChatRulesVersionTimestamp

                packet.WriteInt(0); // CurrentBattlePassSeason
                packet.WriteInt(0); // PassPerkTroopTrainingBoost
                packet.WriteInt(Home.Settings.TriggerHeroAbilityOnDeath); // TriggerHeroAbilityOnDeath
                packet.WriteInt(0); // RejectClanInviteCounter

                packet.WriteInt(0); // PassPerkBuildingBoost
                packet.WriteInt(0); // FILL_ME_4
                packet.WriteInt(0); // PassPerkSavingsPayout
                packet.WriteInt(0); // PassPerkGemDonationCost

                packet.WriteInt(0); // DailyPassTaskProgress1
                packet.WriteInt(0); // DailyPassTaskProgress2
                packet.WriteInt(0); // DailyPassTaskProgress3
            }
            packet.WriteInt(0); //previousArmySize data
            packet.WriteInt(0); //friendlyArmySize data
            packet.WriteInt(0); //unitCounterForEvent data

            packet.WriteInt(0); //unit village2 slot 

            packet.WriteInt(0); //unit village2 new slot data

            packet.WriteInt(0); //slot data
            packet.WriteInt(0); //booster slot data
            packet.WriteInt(Home.Characters.Heroes.Count); //skin slot data
            foreach (var hero in Home.Characters.Heroes)
            {
                packet.WriteInt(hero.Id);
                packet.WriteInt(hero.Skin);
            }
            packet.WriteInt(Home.Characters.Heroes.Count); //pet slot data 
            //Home.Characters.Heroes.Count
            foreach (var hero in Home.Characters.Heroes)
            {
                packet.WriteInt(hero.Id);
                packet.WriteInt(hero.PetId);
            }

            packet.WriteInt(0);
            packet.WriteBoolean(false);

            packet.WriteInt(Home.PlayerLabels.Count);
            foreach (var playerLabel in Home.PlayerLabels)
            {
                packet.WriteInt(playerLabel);
            }

            packet.WriteInt(0);
            packet.WriteInt(0);
        }

        public void AvatarRankingEntry(ByteBuffer packet, int order, bool isPrevious = false)
        {
            RankingEntry(packet, order, isPrevious);

            packet.WriteInt(Home.ExpLevel);
            packet.WriteInt(Home.AttacksWon); //attacks won
            packet.WriteInt(0);
            packet.WriteInt(Home.DefensesWon); //defenses won
            packet.WriteInt(0);
            packet.WriteInt(LeagueUtils.GetLeagueByScore(isPrevious ? Home.PreviousSeasonTrophies : Home.League > 0 ? Home.Trophies : 0));

            packet.WriteString(Home.PreferredDeviceLanguage);
            packet.WriteLong(Home.Id);

            packet.WriteInt(0);
            packet.WriteInt(0);

            var info = Home.AllianceInfo;

            if (info.HasAlliance)
            {
                packet.WriteBoolean(true);
                {
                    packet.WriteLong(info.Id);
                    packet.WriteString(info.Name);
                    packet.WriteInt(info.Badge);
                }
            } else
            {
                packet.WriteBoolean(false);
            }
        }

        public void LeagueMemberEntry(ByteBuffer packet, int order)
        {
            packet.WriteLong(Home.Id);
            packet.WriteString(Home.Name);
            packet.WriteInt(order);
            packet.WriteInt(Home.Trophies);
            packet.WriteInt(0);
            packet.WriteInt(0);
            packet.WriteInt(Home.AttacksWon); //attacks won
            packet.WriteInt(0);
            packet.WriteInt(Home.DefensesWon); //defenses won
            packet.WriteInt(0);

            packet.WriteLong(Home.Id);
            packet.WriteLong(Home.Id);

            var info = Home.AllianceInfo;

            if (info.HasAlliance)
            {
                packet.WriteBoolean(true);
                {
                    packet.WriteLong(info.Id);
                    packet.WriteString(info.Name);
                    packet.WriteInt(info.Badge);
                }
            }
            else
            {
                packet.WriteBoolean(false);
            }

            packet.WriteLong(Home.Id);

        }

        private void RankingEntry(ByteBuffer packet, int order, bool isPrevious = false)
        {
            packet.WriteLong(Home.Id);
            packet.WriteString(Home.Name);

            packet.WriteInt(order);
            packet.WriteInt(isPrevious ? Home.PreviousSeasonTrophies : Home.Trophies);
            packet.WriteInt(200);
        }

        /*public async void AddEntry(AvatarStreamEntry entry)
        {
            lock (Home.Stream)
            {
                while (Home.Stream.Count >= 40)
                    Home.Stream.RemoveAt(0);

                var max = Home.Stream.Count == 0 ? 1 : Home.Stream.Max(x => x.Id);
                entry.Id = max == int.MaxValue ? 1 : max + 1; // If we ever reach that value... but who knows...

                Home.Stream.Add(entry);
            }

            await new AvatarStreamEntryMessage(Device)
            {
                Entry = entry
            }.SendAsync();
        }*/

        /// <summary>
        ///     Validates this session
        /// </summary>
        public void ValidateSession()
        {
            var session = Device.Session;
            session.Duration = (int) DateTime.UtcNow.Subtract(session.SessionStart).TotalSeconds;

            Home.TotalPlayTimeSeconds += session.Duration;

            while (Home.Sessions.Count >= 50) Home.Sessions.RemoveAt(0);

            Home.Sessions.Add(session);
        }

        public async void Save()
        {
            Home.LastSaveTime = DateTime.UtcNow;
/*#if DEBUG
            var st = new Stopwatch();
            st.Start();

            Resources.ObjectCache.CachePlayer(this);
            await PlayerDb.SaveAsync(this);

            st.Stop();
            Logger.Log($"Player {Home.Id} saved in {st.ElapsedMilliseconds}ms.", GetType(), ErrorLevel.Debug);
#else*/
            Resources.ObjectCache.CachePlayer(this);
            await PlayerDb.SaveAsync(this);
//#endif
        }

        public async void SaveAll()
        {
            Home.Status = 0;
            Home.LastSaveTime = DateTime.UtcNow;
            /*#if DEBUG
                        var st = new Stopwatch();
                        st.Start();

                        Resources.ObjectCache.CachePlayer(this);
                        await PlayerDb.SaveAsync(this);

                        st.Stop();
                        Logger.Log($"Player {Home.Id} saved in {st.ElapsedMilliseconds}ms.", GetType(), ErrorLevel.Debug);
            #else*/
            Resources.ObjectCache.CachePlayer(this);
            await PlayerDb.SaveAsync(this);
            //#endif
        }
    }
}
