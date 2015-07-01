using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Windows.Storage;

namespace BusIndia_Universal.Models
{
    public class ExceptionLog
    {

        public async void CreateLogFile(Error objError)
        {           
            string ErrorContent = objError.ErrorEx;
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(ErrorContent.ToString());
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("ErrorLogs.txt", CreationCollisionOption.OpenIfExists);
            using (var stream = await file.OpenStreamForWriteAsync())
            {
                stream.Seek(1, SeekOrigin.End);
                stream.Write(fileBytes, 0, fileBytes.Length);
            }
            StorageFile sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("ErrorLogs.txt");
            String timestamp = await FileIO.ReadTextAsync(sampleFile);           
        }

    }
    public class Error
    {
        private string _Error;
        public string ErrorEx
        {
            get { return _Error; }
            set
            {
                _Error = value;              
            }
        }
    }
}
