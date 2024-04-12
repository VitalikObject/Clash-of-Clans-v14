using ClashofClans.Logic.Home.Slots.Items;

namespace ClashofClans.Logic.Home.Slots
{
    public class VariableSlots : DataSlots
    {
        public void Initialize(Home Home)
        {
            Set(GetCsvID(VariableSlot.StarBonusCounter), 0);
            Set(GetCsvID(VariableSlot.StarBonusCooldown), 0); 
            Set(GetCsvID(VariableSlot.StarBonusTimerEndSubTick), 0); 
            Set(GetCsvID(VariableSlot.StarBonusTimerEndTimestep), 0);
            Set(GetCsvID(VariableSlot.StarBonusTimesCollected), 0);
            Set(GetCsvID(VariableSlot.ChallengeStarted), 0);
            Set(GetCsvID(VariableSlot.ChallengeLayoutIsWar), 0);
            Set(GetCsvID(VariableSlot.FriendListLastOpened), 0);
            Set(GetCsvID(VariableSlot.BeenInArrangedWar), 0);
            Set(GetCsvID(VariableSlot.FILL_ME), 0);
            Set(GetCsvID(VariableSlot.AccountBound), 0);
            Set(GetCsvID(VariableSlot.EventUseTroop), 0);
            Set(GetCsvID(VariableSlot.VillageToGoTo), Home.State);
            Set(GetCsvID(VariableSlot.LootLimitWinCount), 0);
            Set(GetCsvID(VariableSlot.LootLimitTimerEndSubTick), 0);
            Set(GetCsvID(VariableSlot.LootLimitTimerEndTimestamp), 0);
            Set(GetCsvID(VariableSlot.LootLimitCooldown), 0);
            Set(GetCsvID(VariableSlot.Village2BarrackLevel), 0);
            Set(GetCsvID(VariableSlot.LootLimitFreeSpeedUp), 0);
            Set(GetCsvID(VariableSlot.SeenBuilderMenu), 0);
            Set(GetCsvID(VariableSlot.MaxArmyTimerEndSubTick), 0);
            Set(GetCsvID(VariableSlot.MaxArmyTimerEndTimeStamp), 0);
            Set(GetCsvID(VariableSlot.MaxArmyTimerPausedTicksLeft), 0);
        }

        private int GetCsvID(VariableSlot VariableSlot)
        {
            return (37000000 + (int)VariableSlot);
        }
    }
}
