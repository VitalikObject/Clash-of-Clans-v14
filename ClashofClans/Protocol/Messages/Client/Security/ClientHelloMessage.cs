using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server.Account;
using ClashofClans.Protocol.Messages.Server.Security;

namespace ClashofClans.Protocol.Messages.Client.Security
{
    public class ClientHelloMessage : PiranhaMessage
    {
        public ClientHelloMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.Disconnected;
        }

        public int Protocol { get; set; }
        public int KeyVersion { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int Build { get; set; }
        public string FingerprintSha { get; set; }
        public int DeviceType { get; set; }
        public int AppStore { get; set; }

        public override void Decode()
        {
            Protocol = Reader.ReadInt();
            KeyVersion = Reader.ReadInt();
            MajorVersion = Reader.ReadInt();
            MinorVersion = Reader.ReadInt();
            Build = Reader.ReadInt();
            FingerprintSha = Reader.ReadString();
            DeviceType = Reader.ReadInt();
            AppStore = Reader.ReadInt();
        }

        public override async void ProcessAsync()
        {
            if (FingerprintSha == Resources.Fingerprint.Sha)
            { 
                await new ServerHelloMessage(Device)
                {
                }.SendAsync();
            } 
            else
            {
                await new LoginFailedMessage(Device)
                {
                    ErrorCode = 8
                }.SendAsync();
            }
        }
    }
}