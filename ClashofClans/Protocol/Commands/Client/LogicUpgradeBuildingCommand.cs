using ClashofClans.Files.Logic;
using ClashofClans.Logic;
using ClashofClans.Logic.Manager.Items.GameObjects;
using ClashofClans.Utilities.Netty;
using System.Linq;
using System.Numerics;
using System;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicUpgradeBuildingCommand : LogicCommand
    {
        public LogicUpgradeBuildingCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int BuildingId { get; set; }
        public bool UseAltResource { get; set; }

        public override void Decode()
        {
            BuildingId = Reader.ReadInt();
            UseAltResource = Reader.ReadBoolean();

            Reader.ReadByte();
            Reader.ReadByte();
            Reader.ReadByte();

            base.Decode();
        }

        public override void Execute()
        {
            var home = Device.Player.Home;
            var objects = home.GameObjectManager;

            if (BuildingId - 504000000 < 0 && BuildingId != 500000000)
            {
                /*if (objects.IsWorkerAvailable())
                {*/
                var buildings = objects.GetBuildings();

                var index = buildings.FindIndex(b => b.Id == BuildingId);
                if (index > -1)
                {
                    var building = buildings[index];

                    // For Builderbase Tutorial
                    /*if (home.State == 1 && building.Data == 1000034 && building.Level == 0)
                        foreach (var b in buildings)
                            if (b.RequiredTownhallLevel(false) <= 2)
                            {
                                b.StartUnlocking();
                                b.FinishUnlocking();
                            }*/

                    var paid = home.UseResourceByName(
                        UseAltResource
                            ? building.BuildingData.AltBuildResource[building.GetUpgradeLevel()]
                            : building.BuildingData.BuildResource,
                        building.BuildingData.BuildCost[building.GetUpgradeLevel() + 1]);

                    if (paid)
                        building.StartUpgrade();
                    else
                        Device.Disconnect("Payment failed.");
                }
                else
                {
                    Device.Disconnect($"Building {BuildingId} not found.");
                }

                /*}
                else
                {
                    Device.Disconnect("No worker available!");
                }*/
            }
            else if (BuildingId == 500000000)
            {
                var townhallLevel = objects.GetTownhallLevel();
                var buildings = objects.GetBuildings();
                var index = buildings.FindIndex(b => b.Id == BuildingId);

                if (index > -1)
                {
                    var building = buildings[index];

                    if (townhallLevel >= 11 )
                    {

                        if (building.GetTownHallWeaponLevel() == 4)
                        {
                            building.SetTownHallWeaponLevel(0);
                        }
                        else
                        {
                            Device.Disconnect();
                        }
                    }

                    var paid = home.UseResourceByName(
                        UseAltResource
                            ? building.BuildingData.AltBuildResource[building.GetUpgradeLevel()]
                            : building.BuildingData.BuildResource,
                        building.BuildingData.BuildCost[building.GetUpgradeLevel() + 1]);

                    if (paid)
                        building.StartUpgrade();
                    else
                        Device.Disconnect("Payment failed.");
                }
                else
                {
                    Device.Disconnect("Townhall doesn't exist");
                }
            }
            /*else if (BuildingId - 507000000 < 0)
            {
                // Decorations
                //Device.Disconnect("Decorations are not supported for this command yet.");
            }*/
            else if (BuildingId - 508000000 < 0)
            {
                // Traps
                var traps = objects.GetTraps();

                var index = traps.FindIndex(b => b.Id == BuildingId);

                if (index > -1)
                {
                    var trap = traps[index];

                    trap.Level++;
                    //trap.StartUpgrade();
                    /*// For Builderbase Tutorial
                    /*if (home.State == 1 && building.Data == 1000034 && building.Level == 0)
                        foreach (var b in buildings)
                            if (b.RequiredTownhallLevel(false) <= 2)
                            {
                                b.StartUnlocking();
                                b.FinishUnlocking();
                            }

                    var paid = home.UseResourceByName(trap.TrapData.BuildResource, trap.TrapData.BuildCost[trap.GetUpgradeLevel() + 1]);
                    /*var paid = home.UseResourceByName(
                        UseAltResource
                            ? trap.TrapData.AltBuildResource[building.GetUpgradeLevel()]
                            : building.BuildingData.BuildResource,
                        building.BuildingData.BuildCost[building.GetUpgradeLevel() + 1]);

                    if (paid)
                        trap.StartUpgrade();
                    else
                        Device.Disconnect("Payment failed.");*/
                }
                else
                {
                    Device.Disconnect($"Trap {BuildingId} not found.");
                }

                //Device.Disconnect("Traps are not supported for this command yet.");
            }
            else
            {
                var villageObjects = objects.VillageObjects;

                var index = villageObjects.FindIndex(vo => vo.Id == BuildingId);
                if (index > -1)
                {
                    var villageObject = villageObjects[index];

                    var villageObjectData = villageObject.VillageObjectsData;

                    var paid = home.UseResourceByName(villageObjectData.BuildResource, villageObjectData.BuildCost);
                    if (paid)
                        villageObject.StartUpgrade();
                    else
                        Device.Disconnect("Payment failed.");
                }
                else if (BuildingId == 508000000)
                {
                    var buildings = objects.GetBuildings();

                    var building = new Building(home)
                    {
                        Position = new Vector2(27, 57),
                        Data = 39000000,
                        Id = 500000000 + buildings.Count
                    };                    
                }
                else
                {
                    Device.Disconnect($"VillageObject {BuildingId} not found.");
                }
            }
        }
    }
}