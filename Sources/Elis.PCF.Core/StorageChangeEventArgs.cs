namespace Elis.PCF.Core
{
    using System;
    using System.Collections.Generic;

    public class StorageChangeEventArgs : EventArgs
    {
        public List<string> NewFiles { get; set; }
    }
}
