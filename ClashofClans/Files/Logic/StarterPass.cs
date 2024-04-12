using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class StarterPass : Data
    {
        public StarterPass(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string Tasks { get; set; }

        public int TownHallUnlock { get; set; }

        public string Prerequisite { get; set; }

        public int TierScores { get; set; }

        public string RewardType { get; set; }

        public int RewardAmount { get; set; }
    }
}
