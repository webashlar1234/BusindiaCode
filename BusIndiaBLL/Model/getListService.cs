using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;

namespace BusIndiaBLL.Model
{
    public class getListService
    {
        public List<string> getList(string franchUserID, string password,
            string userID, string userKey, string username, string userrole,
            string userstatus, string usertype)
        {
            List<string> servicesNames = new List<string>();


            XmlDocument doc = new XmlDocument();

            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("soapenv:Header"));
            el.SetAttribute("Bar", "some & value");



            return servicesNames;
        }

        public string simpleclass()
        {

            return "";
        }
    }
}
