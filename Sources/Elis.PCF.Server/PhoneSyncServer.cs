namespace Elis.PCF.Server
{
    using System;

    using Elis.PCF.Core;
    using Elis.PCF.Core.Actions;
    using Elis.PCF.Core.Extensions;
    using Elis.PCF.Core.Interfaces;

    class PhoneSyncServer : IPhoneSyncServer
    {
        private readonly IPhoneSyncStorage _storage;

        public PhoneSyncServer(IPhoneSyncStorage storage)
        {
            this._storage = storage;
        }

        public async void WaitCommand()
        {
            while(true)
            {
                
            }
        }

        public IPhoneSyncCommand GetCommand(StorageChangeEventArgs e)
        {
            return new PhoneSyncCommand().XmlDeserialize<IPhoneSyncCommand>(this._storage.ReadFile(e.NewFiles[0]));
        }

        public ActionResult ExecuteAction(IPhoneSyncCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
