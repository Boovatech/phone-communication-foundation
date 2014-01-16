namespace Elis.PCF.Core.Interfaces
{
    using System.IO;

    public interface IPhoneSyncStorageFileInfo
    {
            FileAttributes FileAttribute { get; set; }
            long Length { get; }
            string Name { get; }

            bool IsDirectory();
    }
}
