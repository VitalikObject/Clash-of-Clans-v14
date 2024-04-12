using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class WarLeagues : Data
    {
        public WarLeagues(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int Tier { get; set; }

        public string TID { get; set; }

        public string TIDShort { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string SmallIconExportName { get; set; }

        public string MapTopExportName { get; set; }

        public string MapMidExportName { get; set; }

        public string MapBottomExportName { get; set; }

        public string MapEnvDecoLayerExportName { get; set; }

        public string MapDecoLayerExportName { get; set; }

        public string MapWarDecoLayerExportName { get; set; }

        public bool PromoteEnabled { get; set; }

        public bool DemoteEnabled { get; set; }

        public int WarWinBonusStars { get; set; }

        public int LeagueWinReward { get; set; }

        public int LeaguePosRewardEffect { get; set; }

        public int BonusMedalReward { get; set; }

        public int MinNumMedalBonuses { get; set; }

        public int NumPromotions { get; set; }

        public int NumDemotions { get; set; }

        public int PromoteDemoteDesignBracketSize { get; set; }

        public int SeedA { get; set; }

        public int SeedB { get; set; }

        public bool AllowFirstWarSizeOnly { get; set; }

        public bool Leaderboard { get; set; }

        public bool PreventSpectating { get; set; }
    }
}
