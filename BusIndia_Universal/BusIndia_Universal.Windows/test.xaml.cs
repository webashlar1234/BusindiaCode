using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BusIndia_Universal.BusIndiaServices;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class test : Page
    {
        public test()
        {
            this.InitializeComponent();
        }

     

        private void btninsert_Click(object sender, RoutedEventArgs e)
        {
            /*  SERVICE REFERENCE-SPECIFIC CODE  
           ServiceReference1.ServiceNowSoapClient soapClient = new ServiceReference1.ServiceNowSoapClient();
           soapClient.ClientCredentials.UserName.UserName ="itil";
           soapClient.ClientCredentials.UserName.Password ="itil"; 
            
           ServiceReference1.insert insert = new ExampleWebServiceForWiki.ServiceReference1.insert();
           ServiceReference1.insertResponse response = new ExampleWebServiceForWiki.ServiceReference1.insertResponse();
           //   END OF SERVICE REFERENCE CODE    */

            //   WEB REFERENCE-SPECIFIC CODE


           // BusIndiaServices.GetAvailableServices getcl = new GetAvailableServices();
           // getcl.arg0.
            BusIndiaServices.BusWebServiceClient soapClient = new BusIndia_Universal.BusIndiaServices.BusWebServiceClient();
           soapClient.ClientCredentials.UserName.UserName ="biwstest";
           soapClient.ClientCredentials.UserName.Password ="biwstest";

          
           BusIndiaServices.registerUser insert = new BusIndiaServices.registerUser();
           BusIndiaServices.GetRegisterUserStatusResponse response = new BusIndiaServices.GetRegisterUserStatusResponse();
            //   END OF WEB REFERENCE CODE

           //insert.arg0 = BusIndia_Universal.BusIndiaServices.GetRegisterUserStatus arg0;
           insert.cityTown = "Surat";
           insert.country = "Surat";
           insert.dateOfBirth = "20-11-2015";
           insert.emailId = "abc@gmail.com";
           insert.faxNumber = "123456";
           insert.gender = "M";
           insert.maritalStatus = "M";
           insert.faxNumber = "123456";
           insert.mobileNumber = "8787878787";
           insert.phoneNumber = "0202020";
           insert.state = "GJ";
           insert.streetAddress = "Parle";
           insert.userFullName = "A B C";
           insert.userLoginId = "qwerty123";
           insert.userPassword = "123456";
           insert.zipPostalCode = "454545";
          
           

            try
            {
                soapClient.GetRegisterUserStatusAsync(insert);
                this.lblErrormsg.Text = "Incident Number: " + response.GetRegisterUserStatus.statusCode + "\n";
                this.lblErrormsg.Text += "Sys_id: " + response.GetRegisterUserStatus.message;
            }
            catch (System.Exception error)
            {
                this.lblErrormsg.Text = error.Message;
            }          
        }
    }
}
