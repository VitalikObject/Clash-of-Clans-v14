using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Globals : Data
    {
        public Globals(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int NumberValue { get; set; }

        public bool BooleanValue { get; set; }

        public string TextValue { get; set; }

        public int NumberArray { get; set; }

        public int AltNumberArray { get; set; }

        public string StringArray { get; set; }

        public string AltStringArray { get; set; }
    }
}
