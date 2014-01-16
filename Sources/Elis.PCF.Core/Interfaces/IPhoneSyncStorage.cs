namespace Elis.PCF.Core.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IPhoneSyncStorage
    {
   
        void CreateDirectory(string targetDeviceDirPath);
        void DeleteDirectory(string targetDeviceDirPath);
        bool DirectoryExists(string targetDeviceDirPath);
        bool FileExists(string targetDeviceFilePath);
        List<Microsoft.SmartDevice.Connectivity.Interface.IRemoteFileInfo> GetRemoteDirectoryListing(string searchPattern);
        List<Microsoft.SmartDevice.Connectivity.Interface.IRemoteFileInfo> GetRemoteDirectoryListing();
        List<string> GetDirectoryListing(string searchPattern);
        List<string> GetFilesListing(string searchPattern);
        void ReceiveFile(string sourceDeviceFilePath, string targetDesktopFilePath, bool createNew);
        void SendFile(string sourceDesktopFilePath, string targetDeviceFilePath, bool createNew);
        void CreateFile(string filename, string data);
        void DeleteFile(string filename);
        string ReadFile(string filename);

        event EventHandler<StorageChangeEventArgs> OnChangeNotify;
    }
}
