using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class UpgradeTasks : Data
    {
        public UpgradeTasks(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }
    }
}
