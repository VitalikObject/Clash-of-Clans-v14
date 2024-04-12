using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class BuildingClasses : Data
    {
        public BuildingClasses(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public bool CanBuy { get; set; }

        public bool ShopCategoryResource { get; set; }

        public bool ShopCategoryArmy { get; set; }

        public bool ShopCategoryDefense { get; set; }

        public bool Npc { get; set; }

        public string ParentClass { get; set; }
    }
}
