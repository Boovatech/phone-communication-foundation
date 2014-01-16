namespace Elis.PCF.Core.Interfaces
{
    using Elis.PCF.Core.Actions;

    public interface IPhoneSyncServer
    {
        IPhoneSyncCommand GetCommand(StorageChangeEventArgs e);
        ActionResult ExecuteAction(IPhoneSyncCommand command);
    }
}
