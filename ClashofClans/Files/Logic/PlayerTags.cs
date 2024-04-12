using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class PlayerTags : Data
    {
        public PlayerTags(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public int SortKey { get; set; }
    }
}
