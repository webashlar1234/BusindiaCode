using BusIndiaBLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//using WebServiceClassLiberary.Model;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.Web.Http;

namespace BusIndia_Universal.ClassLiberary
{
    class TEstClass
    {
        public async void postXMLData1()
        {
            string uri = AppStatic.WebServiceBaseURL; // some xml string
            Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);          
            StorageFolder storageFolder = Package.Current.InstalledLocation;
            StorageFile storageFile = await storageFolder.GetFileAsync("Test.xml");
            string stringXml;
            stringXml = await FileIO.ReadTextAsync(storageFile, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            var httpClient = new Windows.Web.Http.HttpClient();
            var info = AppStatic.WebServiceAuthentication;
            var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(info));
            httpClient.DefaultRequestHeaders.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Basic", token);
            httpClient.DefaultRequestHeaders.Add("SOAPAction", "");
            Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, _url);
            httpRequestMessage.Headers.UserAgent.TryParseAdd("Mozilla/4.0");
            IHttpContent content = new HttpStringContent(stringXml, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            httpRequestMessage.Content = content;
            Windows.Web.Http.HttpResponseMessage httpResponseMessage = await httpClient.SendRequestAsync(httpRequestMessage);
            string strXmlReturned = await httpResponseMessage.Content.ReadAsStringAsync();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(strXmlReturned);
            XDocument loadedData = XDocument.Parse(strXmlReturned);
        }

    }
}
