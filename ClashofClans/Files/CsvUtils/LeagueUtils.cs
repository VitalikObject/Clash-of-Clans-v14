using ClashofClans.Files.Logic;

namespace ClashofClans.Files.CsvUtils
{
    public class LeagueUtils
    {
        private static int Data;
        private static Leagues LeagueData => Csv.Tables.Get(Csv.Files.Leagues).GetDataWithId<Leagues>(Data);
        public static int GetPlacementLimitLow(int league)
        {
            Data = 0;
            int League = 0;
            while (league != League)
            {
                if (!string.IsNullOrEmpty(LeagueData.Name))
                    League++;
                Data++;
            }

            return LeagueData.PlacementLimitLow;
        }

        public static int GetPlacementLimitHigh(int league)
        {
            Data = 0;
            int League = 0;
            while (league != League)
            {
                if (!string.IsNullOrEmpty(LeagueData.Name))
                    League++;
                Data++;
            }

            return LeagueData.PlacementLimitHigh;
        }

        public static int GetLeagueByScore(int score)
        {
            Data = 0;
            int League = 0;

            while (score > LeagueData.PlacementLimitLow && score > LeagueData.PlacementLimitHigh)
            {
                if (!string.IsNullOrEmpty(LeagueData.Name))
                    League++;
                Data++;
            }

            return League;
        }
    }
}
