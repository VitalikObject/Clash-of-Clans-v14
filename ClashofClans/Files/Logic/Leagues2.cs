using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Leagues2 : Data
    {
        public Leagues2(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int TrophyLimitLow { get; set; }

        public int TrophyLimitHigh { get; set; }

        public int GoldReward { get; set; }

        public int ElixirReward { get; set; }

        public int BonusGold { get; set; }

        public int BonusElixir { get; set; }

        public int SeasonTrophyReset { get; set; }

        public int MaxDiamondCost { get; set; }
    }
}
