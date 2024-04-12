using System;
using System.IO;
using System.Text;
using ClashofClans.Files.Logic;
using System.Collections.Generic;

namespace ClashofClans.Files
{
    public class Levels
    {
        private int Data;
        public static string MaxHome;
        public static string Globals;
        public static string Calendar;
        public static string EpicJungle;
        public static string StartingHome;
        public static string ChallengeJulyQualifier;
        public List<string> NpcLevels = new List<string>();
        private Npcs NpcsData => Csv.Tables.Get(Csv.Files.Npcs).GetDataWithId<Npcs>(Data);
        private int NpcDataLinesCount => Csv.Tables.Get(Csv.Files.Npcs).Count();

        public Levels()
        {
            if (Directory.Exists("GameAssets/level"))
            {
                if (File.Exists("GameAssets/starting_home.json"))
                {
                    Globals = File.ReadAllText("GameAssets/globals.json", Encoding.UTF8);
                    Calendar = File.ReadAllText("GameAssets/calendar.json", Encoding.UTF8);
                    MaxHome = File.ReadAllText("GameAssets/level/townhall14.json", Encoding.UTF8);
                    StartingHome = File.ReadAllText("GameAssets/starting_home.json", Encoding.UTF8);
                    EpicJungle = File.ReadAllText("GameAssets/level/challenge_epic_jungle.json", Encoding.UTF8);
                    ChallengeJulyQualifier = File.ReadAllText("GameAssets/level/challenge_july_qualifier_2021.json", Encoding.UTF8);

                    while (NpcDataLinesCount > Data)
                    {
                        if (!string.IsNullOrEmpty(NpcsData.LevelFile))
                            NpcLevels.Add(File.ReadAllText($"GameAssets/{NpcsData.LevelFile}", Encoding.UTF8));
                        Data++;
                    }
                }
                else
                {
                    Console.WriteLine("Failed to load starting home.");
                    Program.Exit();
                }
            }
            else
            {
                Console.WriteLine("GameAssets folder doesn't exist.");
                Program.Exit();
            }
        }
    }
}