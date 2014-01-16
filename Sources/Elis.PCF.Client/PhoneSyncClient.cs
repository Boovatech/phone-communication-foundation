namespace Elis.PCF.Client
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Elis.PCF.Core;
    using Elis.PCF.Core.Actions;
    using Elis.PCF.Core.Extensions;
    using Elis.PCF.Core.Interfaces;

    public class PhoneSyncClient : IPhoneSyncClient
    {
        private readonly IPhoneSyncStorage _storage;

        public PhoneSyncClient (IPhoneSyncStorage storage)
        {
            this._storage = storage;
        }

        public async Task<ActionResult> SendCommand(PhoneSyncCommand command)
        {
            try
            {
                this._storage.CreateFile("./"+command.Id+".xml", command.XmlSerialize<PhoneSyncCommand>());
                this._storage.SendFile("./" + command.Id + ".xml", "inbox//command.xml", true);
                while (!this._storage.FileExists("outbox//" + command.Id + ".xml"))
                {
                    Thread.Sleep(1000);
                }
                this._storage.ReceiveFile("outbox//" + command.Id + ".xml", "./" + command.Id + ".xml", true);
                var result = new ActionResult().XmlDeserialize<ActionResult>(this._storage.ReadFile("./" + command.Id + ".xml"));
                return result;
            }
            catch (Exception e)
            {
                return new ActionResult{IsComplete = false, Error="Not complete operation"};
            }
            
        }

    }
}
