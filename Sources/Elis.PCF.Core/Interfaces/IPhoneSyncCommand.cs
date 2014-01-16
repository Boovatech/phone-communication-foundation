namespace Elis.PCF.Core.Interfaces
{
    using System;

    public interface IPhoneSyncCommand
    {
        Guid Id { get; set; }
        string ActionName { get; set; }
        object Param { get; set; }
    }
}
