namespace Elis.PCF.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using Elis.PCF.Core;
    using Elis.PCF.Core.Interfaces;

    using Microsoft.SmartDevice.Connectivity;
    using Microsoft.SmartDevice.Connectivity.Wrapper;

    public class SmartDevicePhoneSyncStorage : IPhoneSyncStorage
    {

        public delegate void StorageChangeEventHandler(object sender, StorageChangeEventArgs a);

        public event EventHandler<StorageChangeEventArgs> OnChangeNotify;

        protected virtual void OnRaiseStorageChangeEvent(StorageChangeEventArgs e)
        {
            EventHandler<StorageChangeEventArgs> handler = this.OnChangeNotify;
            if (handler != null) handler(this, e);
        }

        private readonly Microsoft.SmartDevice.Connectivity.Interface.IRemoteIsolatedStorageFile _storage;
        private List<Microsoft.SmartDevice.Connectivity.Interface.IRemoteFileInfo> _baseFileList;
       

        public SmartDevicePhoneSyncStorage(Microsoft.SmartDevice.Connectivity.Interface.IRemoteIsolatedStorageFile storage)
        {
            this._storage = storage;
            this._baseFileList = this.GetRemoteDirectoryListing("outbox");
            

        }
        
        public void CreateDirectory(string targetDeviceDirPath)
        {
            this._storage.CreateDirectory(targetDeviceDirPath);
        }
        public void DeleteDirectory(string targetDeviceDirPath)
        {
            this._storage.DeleteDirectory(targetDeviceDirPath);
        }
        public bool DirectoryExists(string targetDeviceDirPath)
        {
            return this._storage.DirectoryExists(targetDeviceDirPath);
        }

        public bool FileExists(string targetDeviceFilePath)
        {
            return this._storage.FileExists(targetDeviceFilePath);
        }

        public List<Microsoft.SmartDevice.Connectivity.Interface.IRemoteFileInfo> GetRemoteDirectoryListing(string searchPattern)
        {
            return this._storage.GetDirectoryListing(searchPattern);
        }
        public List<Microsoft.SmartDevice.Connectivity.Interface.IRemoteFileInfo> GetRemoteDirectoryListing()
        {
            return this._storage.GetDirectoryListing(string.Empty);
        }

        public List<string> GetDirectoryListing(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFilesListing(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public void ReceiveFile(string sourceDeviceFilePath, string targetDesktopFilePath, bool createNew)
        {
            this._storage.ReceiveFile(sourceDeviceFilePath, targetDesktopFilePath, createNew);
        }
        public void SendFile(string sourceDesktopFilePath, string targetDeviceFilePath, bool createNew)
        {
            this._storage.SendFile(sourceDesktopFilePath, targetDeviceFilePath, createNew);
        }
        public void CreateFile(string file, string data)
        {
            using (StreamWriter outfile = new StreamWriter(file))
            {
                outfile.Write(data);
            }
        }
        public void DeleteFile(string filename)
        {
            var remoteFileObject = this._storage as RemoteIsolatedStorageFileObject;

            if (remoteFileObject != null)
            {
                BindingFlags eFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                var fieldInfo = (typeof(RemoteIsolatedStorageFileObject)).GetField("mRemoteIsolatedStorageFile", eFlags);
                RemoteIsolatedStorageFile RIStorageFile;
                if (fieldInfo != null)
                {
                    RIStorageFile = fieldInfo.GetValue(remoteFileObject) as RemoteIsolatedStorageFile;
                    RIStorageFile.DeleteFile(filename);
                }
            }
        }

        public string ReadFile(string filename)
        {
            throw new NotImplementedException();
        }

    }
}
