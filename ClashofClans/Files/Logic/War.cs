using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class War : Data
    {
        public War(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int TeamSize { get; set; }

        public int PreparationMinutes { get; set; }

        public int WarMinutes { get; set; }

        public bool DisableProduction { get; set; }

        public bool AllowArrangedWar { get; set; }
    }
}
