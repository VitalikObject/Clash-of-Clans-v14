using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Missions : Data
    {
        public Missions(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string Dependencies { get; set; }

        public int MissionCategory { get; set; }

        public int VillageType { get; set; }

        public bool FirstStep { get; set; }

        public bool Deprecated { get; set; }

        public string Action { get; set; }

        public string Character { get; set; }

        public string FixVillageObject { get; set; }

        public string BuildBuilding { get; set; }

        public int BuildBuildingLevel { get; set; }

        public int BuildBuildingCount { get; set; }

        public string DefendNPC { get; set; }

        public string AttackNPC { get; set; }

        public int Delay { get; set; }

        public int TrainTroops { get; set; }

        public bool ShowMap { get; set; }

        public string ClientCondition { get; set; }

        public string ClientStartAction { get; set; }

        public string TutorialText { get; set; }

        public int TutorialStep { get; set; }

        public bool Darken { get; set; }

        public string TutorialTextBox { get; set; }

        public string TutorialCharacter { get; set; }

        public string CharacterSWF { get; set; }

        public bool LoopAnim { get; set; }

        public bool SwitchAnim { get; set; }

        public string SpeechBubble { get; set; }

        public bool RightAlignTextBox { get; set; }

        public string ButtonText { get; set; }

        public string TutorialMusic { get; set; }

        public string TutorialSound { get; set; }

        public string HighlightArrowPath { get; set; }

        public string HighlightArrowDirection { get; set; }

        public string ClientAction { get; set; }

        public string RewardResource { get; set; }

        public int RewardResourceCount { get; set; }

        public int RewardXP { get; set; }

        public string RewardTroop { get; set; }

        public int RewardTroopCount { get; set; }

        public int CustomData { get; set; }

        public int Villagers { get; set; }

        public bool ForceCamera { get; set; }

        public bool WaitUntilPopupIsClosed { get; set; }

        public int LinkedReengagementStep { get; set; }

        public bool RewindOnConditionFail { get; set; }

        public bool ProgressWithCondition { get; set; }
    }
}
