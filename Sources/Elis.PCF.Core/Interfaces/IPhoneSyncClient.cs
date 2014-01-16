namespace Elis.PCF.Core.Interfaces
{
    using System.Threading.Tasks;

    using Elis.PCF.Core.Actions;

    public interface IPhoneSyncClient 
    {
        Task<ActionResult> SendCommand(PhoneSyncCommand command);
    }
}
