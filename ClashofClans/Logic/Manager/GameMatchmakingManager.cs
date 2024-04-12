using System;
using System.Timers;
using ClashofClans.Database;
using ClashofClans.Protocol.Messages.Server.Battle;

namespace ClashofClans.Logic.Manager
{
    public class GameMatchmakingManager
    {
        public System.Timers.Timer searchTimer { get; set; }
        private Device device;

        public void Init(Device dvc)
        {
            if (searchTimer != null)
                searchTimer.Stop();

            device = dvc;
            FindEnemy();
        }
        private void Destruct()
        {
            device = null;
            searchTimer.Stop();
        }
        private async void FindEnemy()
        {
            var enemy = await PlayerDb.GetRandomCachedPlayer(device.Player);

            if (enemy == null)
            {
                InitSearchTimer(device.Player.Home.Battle);
            }
            else if (enemy.Home.AllianceInfo.Id == device.Player.Home.AllianceInfo.Id)
            {
                if ( searchTimer == null )
                    InitSearchTimer(device.Player.Home.Battle);
            }
            else
            {
                device.Player.Home.Battle.SetEnemyData(enemy);

                await new EnemyHomeDataMessage(device)
                {
                    Enemy = enemy
                }.SendAsync();
            }
        }
        private void InitSearchTimer(Battle battle)
        {
            searchTimer = new System.Timers.Timer(2000);
            searchTimer.Elapsed += SearchForPlayer;
            searchTimer.AutoReset = true;
            searchTimer.Enabled = true;
        }
        private async void SearchForPlayer(Object source, ElapsedEventArgs e)
        {
            var enemy = await PlayerDb.GetRandomCachedPlayer(device.Player);
            if (enemy != null && enemy.Home.AllianceInfo.Id != device.Player.Home.AllianceInfo.Id)
            {
                device.Player.Home.Battle.SetEnemyData(enemy);

                await new EnemyHomeDataMessage(device)
                {
                    Enemy = enemy
                }.SendAsync();

                Destruct();
            }
        }
    }
}
