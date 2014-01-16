namespace Elis.PCF.Core
{
    using System;

    using Elis.PCF.Core.Interfaces;

    public class PhoneSyncCommand : IPhoneSyncCommand
    {
        public Guid Id { get; set; }
        public string ActionName { get; set; }
        public object Param { get; set; }

        public PhoneSyncCommand()
        {

        }
        public PhoneSyncCommand (string name, string param )
        {
            this.Id = Guid.NewGuid();
            this.ActionName = name;
            this.Param = (object) param;
        }
    }
}
