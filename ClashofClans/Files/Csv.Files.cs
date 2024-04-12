using System;
using System.Collections.Generic;
using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;
using ClashofClans.Files.Logic;

namespace ClashofClans.Files
{
    public partial class Csv
    {
        public enum Files
        {
            BuildingClasses = 1,
            Buildings = 2,
            Globals = 3,
            ExperienceLevels = 4,
            Obstacles = 5,
            VillageObjects = 6,
            Missions = 7,
            Decos = 8,
            Traps = 9,
            Achievements = 10,
            Resources = 11,
            Npcs = 12,
            Leagues = 13,
            Regions = 14
        }

        public static Dictionary<Files, Type> DataTypes = new Dictionary<Files, Type>();

        static Csv()
        {
            DataTypes.Add(Files.BuildingClasses, typeof(BuildingClasses));
            DataTypes.Add(Files.Buildings, typeof(Buildings));
            DataTypes.Add(Files.Globals, typeof(Globals));
            DataTypes.Add(Files.ExperienceLevels, typeof(ExperienceLevels));
            DataTypes.Add(Files.Obstacles, typeof(Obstacles));
            DataTypes.Add(Files.VillageObjects, typeof(VillageObjects));
            DataTypes.Add(Files.Missions, typeof(Missions));
            DataTypes.Add(Files.Decos, typeof(Decos));
            DataTypes.Add(Files.Traps, typeof(Traps));
            DataTypes.Add(Files.Achievements, typeof(Achievements));
            DataTypes.Add(Files.Resources, typeof(Logic.Resources));
            DataTypes.Add(Files.Npcs, typeof(Npcs));
            DataTypes.Add(Files.Leagues, typeof(Leagues));
            DataTypes.Add(Files.Regions, typeof(Regions));
        }

        public static Data Create(Files file, Row row, DataTable dataTable)
        {
            if (DataTypes.ContainsKey(file)) return Activator.CreateInstance(DataTypes[file], row, dataTable) as Data;

            return null;
        }
    }
}