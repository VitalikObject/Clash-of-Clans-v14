using System.Linq;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicChangeVillageBackgroundCommand : LogicCommand
    {
        public LogicChangeVillageBackgroundCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int BackgroundId { get; set; }
        private int BackgroundType { get; set; }
        public override void Decode()
        {
            BackgroundId = Reader.ReadInt();
            BackgroundType = Reader.ReadByte();
            Reader.ReadInt();
        }
        public override void Execute()
        {        
            if (Device.Player.Home.GameObjectManager.SelectedBackgrounds.Any())
            {
                switch (BackgroundType)
                {
                    case 0:
                        Device.Player.Home.GameObjectManager.SelectedBackgrounds[0] = BackgroundId;
                        break;
                    case 1:
                        if (Device.Player.Home.GameObjectManager.SelectedBackgrounds.Count == 2)
                        {
                            Device.Player.Home.GameObjectManager.SelectedBackgrounds[1] = BackgroundId;
                        }
                        else
                        {
                            Device.Player.Home.GameObjectManager.SelectedBackgrounds.Add(BackgroundId);
                        }
                        break;
                }
            }
            else
            {
                if (BackgroundType == 1)
                {
                    Device.Player.Home.GameObjectManager.SelectedBackgrounds.Add(BackgroundId);
                }
                else
                {
                    Device.Player.Home.GameObjectManager.SelectedBackgrounds.Add(0);
                    Device.Player.Home.GameObjectManager.SelectedBackgrounds.Add(BackgroundId);
                }
            }

            Device.Player.Home.GameObjectManager.Save();
        }
    }
}
