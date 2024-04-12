using System;
using System.Threading;
using ClashofClans.Utilities.Utils;

namespace ClashofClans
{
    public static class Program
    {
        private static void Main()
        {
            Console.Title = "Clash of Clans Server Emulator [v14.211.7]";

            Resources.Initialize();

            if (ServerUtils.IsLinux())
            {
                Thread.Sleep(Timeout.Infinite);
            }
            else
            {
                Logger.Log("Press any key to shutdown the server.", null);
                Console.Read();
            }

            Shutdown();
        }

        public static async void Shutdown()
        {
            Console.WriteLine("Shutting down...");

            await Resources.Netty.Shutdown();

            try
            {
                Console.WriteLine("Saving players...");

                lock (Resources.Players.SyncObject)
                {
                    foreach (var player in Resources.Players.Values) player.SaveAll();
                }

                Console.WriteLine("All players saved.");
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't save all players.");
            }

            await Resources.Netty.ShutdownWorkers();
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}