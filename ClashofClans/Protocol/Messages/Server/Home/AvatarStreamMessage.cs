using ClashofClans.Logic;
using System.Collections.Generic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic.Home.StreamEntry;

namespace ClashofClans.Protocol.Messages.Server
{
    public class AvatarStreamMessage : PiranhaMessage
    {
        public AvatarStreamMessage(Device device) : base(device)
        {
            Id = 25418;
        }

        public List<AvatarStreamEntry> Entries { get; set; }

        public override void EncodeAsync()
        {
            /*Writer.WriteInt(Entries.Count);

            foreach (var entry in Entries) entry.Encode(Writer);*/

            Writer.WriteInt(1);
            Writer.WriteHex("00000002000000025d4af282010000000401603a33");
            Writer.WriteString("Antz");
            Writer.WriteHex("0000004f00000009000198ef00");
            Writer.WriteString("{\"villageType\":0,\"loot\":[[3000002,553798],[3000001,577147],[3000003,5691]],\"availableLoot\":[[3000000,0],[3000001,577147],[3000002,553798],[3000003,5691],[],[],[],[3000007,0],[3000008,0],[3000009,0],[3000010,0],[3000011,0],[3000012,0]],\"units\":[[4000008,11],[28000001,1],[28000000,1]],\"skins\":[[28000001,52000002],[28000000,52000000]],\"spells\":[[26000000,9]],\"levels\":[[26000000,5],[4000008,3],[28000001,9],[28000000,11]],\"stats\":{\"townhallDestroyed\":true,\"battleEnded\":true,\"allianceUsed\":false,\"destructionPercentage\":100,\"battleTime\":150,\"originalAttackerScore\":1859,\"attackerScore\":15,\"originalDefenderScore\":1625,\"defenderScore\":-15,\"allianceName\":\"COC CHAMPS\",\"attackerStars\":3,\"homeID\":[4,23083571],\"allianceBadge\":0,\"allianceBadge2\":1526733141,\"allianceID\":[18,1818937],\"deployedHousingSpace\":315,\"armyDeploymentPercentage\":117,\"allianceExp\":14,\"allianceExp2\":4,\"maxOutArmyUsed\":false}}");
            Writer.WriteHex("00000000000000000e000000d300000004");
            Writer.WriteString("Admin");
            Writer.WriteHex("010000003400000001b1a20ec8");
        }
    }
}