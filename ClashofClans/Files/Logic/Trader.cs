using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Trader : Data
    {
        public Trader(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string Items { get; set; }

        public int ItemAmounts { get; set; }

        public int Costs { get; set; }
    }
}
