using ClashofClans.Logic.Manager.Items.GameObjects;

namespace ClashofClans.Logic.Manager.Items.Components
{
    public class ResourceStorageComponent : Component
    {
        public ResourceStorageComponent(GameObject gameObject) : base(gameObject)
        {
            Type = 6;
        }

        public int MaxStoredGold(int level)
        {
            var data = ((Building) Parent).BuildingData;
            return data.MaxStoredGold.Length > level ? data.MaxStoredGold[level] : 0;
        }

        public int MaxStoredGold2(int level)
        {
            var data = ((Building) Parent).BuildingData;
            return data.MaxStoredGold2.Length > level ? data.MaxStoredGold2[level] : 0;
        }

        public int MaxStoredElixir(int level)
        {
            var data = ((Building) Parent).BuildingData;
            return data.MaxStoredElixir.Length > level ? data.MaxStoredElixir[level] : 0;
        }

        public int MaxStoredElixir2(int level)
        {
            var data = ((Building) Parent).BuildingData;
            return data.MaxStoredElixir2.Length > level ? data.MaxStoredElixir2[level] : 0;
        }

        public int MaxStoredDarkElixir(int level)
        {
            var data = ((Building) Parent).BuildingData;
            return data.MaxStoredDarkElixir.Length > level ? data.MaxStoredDarkElixir[level] : 0;
        }
    }
}