namespace Elis.PCF.Core.Actions
{
    public class ActionResult
    {
        public bool IsComplete { get; set; }
        public string Error { get; set; }
    }

    public class ActionResult<T> : ActionResult
    {
        public T Result { get; set; }
    }
}
