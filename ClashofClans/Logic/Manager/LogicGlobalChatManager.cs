using ClashofClans.Logic.Manager.Items;
using ClashofClans.Protocol.Messages.Server.Chat;

namespace ClashofClans.Logic.Manager
{
    public class LogicGlobalChatManager
    {
        public async void Process(GlobalChatEntry entry)
        {
            foreach (var player in Resources.Players.Values)
                if (player.Device != null)
                {
                    await new GlobalChatLineMessage(player.Device)
                    {
                        Message = entry.Message,
                        Name = entry.SenderName,
                        ExpLevel = entry.SenderExpLevel,
                        League = entry.SenderLeague,
                        AccountId = entry.SenderId
                    }.SendAsync();
                }
        }
    }
}
