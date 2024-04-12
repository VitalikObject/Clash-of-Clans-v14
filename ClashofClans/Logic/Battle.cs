using ClashofClans.Files;
using ClashofClans.Files.Logic;
using ClashofClans.Utilities.LogicMath;
using ClashofClans.Protocol.Messages.Server;

namespace ClashofClans.Logic
{
    public class Battle
    {
        private int Data;
        private int League;
        private int BattleStars { get; set; }
        private int BattlePercentage { get; set; }
        private Player EnemyData { get; set; }
        private bool BattleStatus { get; set; }
        private Leagues LeagueData => Csv.Tables.Get(Csv.Files.Leagues).GetDataWithId<Leagues>(Data);
        private Globals GlobalsData => Csv.Tables.Get(Csv.Files.Globals).GetDataWithId<Globals>(Data);

        public async void StartBattle(Device device)
        {
            if (!GetBattleStatus())
            {
                SetBattleStatus(true);
            }
            else
            {
                Logger.Log("Battle already started", null, Logger.ErrorLevel.Error);
                await new OutOfSyncMessage(device).SendAsync();
            }
        }

        public async void EndBattle(Player player, Device device)
        {
            if(GetBattleStatus())
            {
                SetBattleStatus(false);

                if (GetBattleStars() > 3)
                {
                    await new OutOfSyncMessage(device).SendAsync();
                    return;
                }

                var enemy = GetEnemyData();

                int attackerScore = player.Home.Trophies;
                int defenderScore = enemy.Home.Trophies;

                int multiplier = GetBattleStars();

                if (GetBattleStars() <= 0)
                {
                    multiplier = GetScoreMultiplierOnAttackLose();
                }

                int newAttackerScore;
                int newDefenderScore;

                if (EloOffsetDampeningEnabled())
                {
                    newAttackerScore = LogicELOMath.CalculateNewRating(GetBattleStars() > 0, attackerScore, defenderScore, 20 * multiplier, GetEloDampeningFactor(), GetEloDampeningLimit(), GetEloDampeningScoreLimit());
                    newDefenderScore = LogicELOMath.CalculateNewRating(GetBattleStars() <= 0, defenderScore, attackerScore, 20 * multiplier, GetEloDampeningFactor(), GetEloDampeningLimit(), GetEloDampeningScoreLimit());
                }
                else
                {
                    newAttackerScore = LogicELOMath.CalculateNewRating(GetBattleStars() > 0, attackerScore, defenderScore, 20 * multiplier);
                    newDefenderScore = LogicELOMath.CalculateNewRating(GetBattleStars() <= 0, defenderScore, attackerScore, 20 * multiplier);
                }

                int attackerGainCount = newAttackerScore - attackerScore;
                int defenderGainCount = newDefenderScore - defenderScore;

                if (attackerScore < 1000 && attackerGainCount < 0)
                {
                    attackerGainCount = attackerScore * attackerGainCount / 1000;
                }

                if (defenderScore < 1000 && defenderGainCount < 0)
                {
                    defenderGainCount = defenderScore * defenderGainCount / 1000;
                }

                if (LogicELOMath.CalculateNewRating(true, attackerScore, defenderScore, 60) > attackerScore)
                {
                    if (GetBattleStars() <= 0)
                    {
                        if (attackerGainCount >= 0)
                        {
                            attackerGainCount = -1;
                        }
                    }
                    else
                    {
                        if (attackerGainCount <= 0)
                        {
                            attackerGainCount = 1;
                        }

                        if (defenderGainCount >= 0)
                        {
                            defenderGainCount = -1;
                        }
                    }
                }

                newAttackerScore = LogicMath.Max(attackerScore + attackerGainCount, 0);
                newDefenderScore = LogicMath.Max(defenderScore + defenderGainCount, 0);

                player.Home.Trophies = newAttackerScore;
                enemy.Home.Trophies = newDefenderScore;

                if (GetBattleStars() > 0)
                {
                    SetBattleWin(player);
                    SetBattleLose(enemy, false);
                    player.Home.AttacksWon++;
                }
                else
                {
                    SetBattleLose(player);
                    SetBattleWin(enemy);
                    enemy.Home.DefensesWon++;
                }

                await Database.PlayerDb.SaveAsync(enemy);

                enemy.Save();

                Logger.Log($"The battle is over. Attacker id: {player.Home.Id}, attacker name: {player.Home.Name}, defender id: {enemy.Home.Id}, defender name: {enemy.Home.Name}, percentage: {GetBattlePercenatage() + "%"}, stars: {GetBattleStars()}, trophies won: {newAttackerScore - attackerScore}", null, Logger.ErrorLevel.Debug);

                Destruct();
            }
            else
            {
                Logger.Log("Battle already ended", null, Logger.ErrorLevel.Error);
                await new OutOfSyncMessage(device).SendAsync();
            }
        }

        public void Destruct()
        {
            Data = 0;
            League = 0;

            SetBattleStars(0);
            SetEnemyData(null);
            SetBattleStatus(false);
            SetBattlePercenatage(0);
        }

        private void SetBattleWin(Player player)
        {
            Data = 0;
            League = 0;
            while (player.Home.Trophies > LeagueData.PlacementLimitLow && player.Home.Trophies > LeagueData.PlacementLimitHigh)
            {
                if (!string.IsNullOrEmpty(LeagueData.Name))
                    League++;
                Data++;
            }

            player.Home.League = League;
        }

        private void SetBattleLose(Player player, bool isAttacker = true)
        {
            Data = 0;
            League = 0;
            if (isAttacker || player.Home.League != 0)
            {
                while (player.Home.Trophies > LeagueData.PlacementLimitLow && player.Home.Trophies > LeagueData.PlacementLimitHigh)
                {
                    if (!string.IsNullOrEmpty(LeagueData.Name))
                        League++;
                    Data++;
                }

                player.Home.League = League;
            }
        }

        public void SetBattleStatus(bool status)
        {
            BattleStatus = status;
        }

        public bool GetBattleStatus()
        {
            return BattleStatus;
        }

        public void SetBattleStars(int stars)
        {
            BattleStars = stars;
        }

        public int GetBattleStars()
        {
            return BattleStars;
        }

        public void SetBattlePercenatage(int percentage)
        {
            BattlePercentage = percentage;
        }

        public int GetBattlePercenatage()
        {
            return BattlePercentage;
        }

        public void SetEnemyData(Player enemy)
        {
            EnemyData = enemy;
        }

        public Player GetEnemyData()
        {
            return EnemyData;
        }

        private bool EloOffsetDampeningEnabled()
        {
            Data = 0;
            string EloOffsetDampeningEnabled = string.Empty;
            while (EloOffsetDampeningEnabled != "ELO_OFFSET_DAMPENING_ENABLED")
            {
                if (!string.IsNullOrEmpty(GlobalsData.Name))
                    EloOffsetDampeningEnabled = GlobalsData.Name;
                Data++;
            }
            Data--;

            return GlobalsData.BooleanValue;
        }

        private int GetEloDampeningFactor()
        {
            Data = 0;
            string EloDampeningFactor = string.Empty;
            while (EloDampeningFactor != "ELO_OFFSET_DAMPENING_FACTOR")
            {
                if (!string.IsNullOrEmpty(GlobalsData.Name))
                    EloDampeningFactor = GlobalsData.Name;
                Data++;
            }
            Data--;

            return GlobalsData.NumberValue;
        }

        private int GetEloDampeningLimit()
        {
            Data = 0;
            string EloDampeningLimit = string.Empty;
            while (EloDampeningLimit != "ELO_OFFSET_DAMPENING_LIMIT")
            {
                if (!string.IsNullOrEmpty(GlobalsData.Name))
                    EloDampeningLimit = GlobalsData.Name;
                Data++;
            }
            Data--;

            return GlobalsData.NumberValue;
        }

        private int GetEloDampeningScoreLimit()
        {
            Data = 0;
            string EloDampeningScoreLimit = string.Empty;
            while (EloDampeningScoreLimit != "ELO_OFFSET_DAMPENING_SCORE_LIMIT")
            {
                if (!string.IsNullOrEmpty(GlobalsData.Name))
                    EloDampeningScoreLimit = GlobalsData.Name;
                Data++;
            }
            Data--;

            return GlobalsData.NumberValue;
        }

        private int GetScoreMultiplierOnAttackLose()
        {
            Data = 0;
            string ScoreMultiplierOnAttackLose = string.Empty;
            while (ScoreMultiplierOnAttackLose != "SCORE_MULTIPLIER_ON_ATTACK_LOSE")
            {
                if (!string.IsNullOrEmpty(GlobalsData.Name))
                    ScoreMultiplierOnAttackLose = GlobalsData.Name;
                Data++;
            }
            Data--;

            return GlobalsData.NumberValue;
        }
    }
}
