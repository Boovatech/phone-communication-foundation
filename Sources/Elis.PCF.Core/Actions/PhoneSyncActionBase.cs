namespace Elis.PCF.Core.Actions
{
    public abstract class PhoneSyncActionBase
    {
        protected abstract ActionResult Execute();
    }

    public abstract class PhoneSyncActionBase<T> : PhoneSyncActionBase
    {
        private T _baseParam { get; set; }

        public PhoneSyncActionBase(object Param)
        {
            this._baseParam = this.GetParam(Param);
        }

        protected virtual T GetParam(object Param)
        {
            return (T)Param;
        }
    }
}
