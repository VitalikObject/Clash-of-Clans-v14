using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Server.Account
{
    public class LoginFailedMessage : PiranhaMessage
    {
        public LoginFailedMessage(Device device) : base(device)
        {
            Id = 20103;
            Version = 4;
        }

        public byte ErrorCode { get; set; }
        public int SecondsUntilMaintenanceEnds { get; set; }
        public string Reason { get; set; }
        public string ResourceFingerprintData { get; set; }
        public string ContentUrl { get; set; }
        public string UpdateUrl { get; set; }

        // 1  = Custom Message
        // 7  = Patch
        // 8  = Update Available
        // 9  = Failed to Connect
        // 10 = Maintenance
        // 11 = Banned
        // 13 = Acc Locked PopUp
        // 16 = Updating Cr/Maintenance
        // 18 = Chinese Text?

        public override void EncodeAsync()
        {
            Writer.WriteInt(ErrorCode); // ErrorCode
            Writer.WriteString(ResourceFingerprintData); // Fingerprint
            Writer.WriteString(null);
            Writer.WriteString(ContentUrl); // Content URL
            Writer.WriteString(UpdateUrl); // Update URL
            Writer.WriteString(Reason);
            Writer.WriteInt(SecondsUntilMaintenanceEnds);
        }
    }
}