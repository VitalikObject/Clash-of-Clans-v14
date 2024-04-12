using System.Collections.Generic;
using System.Threading.Tasks;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files
{
    public partial class Csv
    {
        public static readonly List<string> Gamefiles = new List<string>();
        public static Gamefiles Tables;

        public Csv()
        {
            Gamefiles.Add("GameAssets/logic/building_classes.csv");
            Gamefiles.Add("GameAssets/logic/buildings.csv");
            Gamefiles.Add("GameAssets/logic/globals.csv");
            Gamefiles.Add("GameAssets/logic/experience_levels.csv");
            Gamefiles.Add("GameAssets/logic/obstacles.csv");
            Gamefiles.Add("GameAssets/logic/village_objects.csv");
            Gamefiles.Add("GameAssets/logic/missions.csv");
            Gamefiles.Add("GameAssets/logic/decos.csv");
            Gamefiles.Add("GameAssets/logic/traps.csv");
            Gamefiles.Add("GameAssets/logic/achievements.csv");
            Gamefiles.Add("GameAssets/logic/resources.csv");
            Gamefiles.Add("GameAssets/logic/npcs.csv");
            Gamefiles.Add("GameAssets/logic/leagues.csv");
            Gamefiles.Add("GameAssets/logic/regions.csv");

            Tables = new Gamefiles();

            Parallel.ForEach(Gamefiles,
                file => { Tables.Initialize(new Table(file), (Files) Gamefiles.IndexOf(file) + 1); });

            Logger.Log($"{Gamefiles.Count} Gamefile(s) loaded.", GetType());
        }
    }
}