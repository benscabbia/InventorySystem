using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class EbayAPI
    {
        private static ApiContext apiContext = null;

        static void GetEbayTime()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +");
            Console.WriteLine("+ - HelloWorld                        +");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");

            //[Step 1] Initialize eBay ApiContext object
            ApiContext apiContext = GetApiContext();
            //[Step 2] Create Call object and execute the Call
            GeteBayOfficialTimeCall apiCall = new GeteBayOfficialTimeCall(apiContext);
            Console.WriteLine("Begin to call eBay API, please wait ...");
            DateTime officialTime = apiCall.GeteBayOfficialTime();
            Console.WriteLine("End to call eBay API, show call result:");

            //[Step 3] Handle the result returned
            Console.WriteLine("eBay official Time: " + officialTime);
            Console.WriteLine();
            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();

        }

        /// <summary>
        /// Populate eBay SDK ApiContext object with data from application configuration file
        /// </summary>
        /// 
        /// <returns>ApiContext</returns>
        static ApiContext GetApiContext()
        {
            //apiContext is a singleton,
            //to avoid duplicate config file reading
            if (apiContext != null)
            {
                return apiContext;
            }
            else
            {
                apiContext = new ApiContext();

                //set Api Server Url
                apiContext.SoapApiServerUrl = ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
                //set Api Token to access eBay Api Server
                ApiCredential apiCredential = new ApiCredential();
                apiCredential.eBayToken = ConfigurationManager.AppSettings["UserAccount.ApiToken"];
                apiCredential.ApiAccount.Application = ConfigurationManager.AppSettings["UserAccount.AppID"];
                apiCredential.ApiAccount.Developer = ConfigurationManager.AppSettings["UserAccount.DevID"];
                apiCredential.ApiAccount.Certificate = ConfigurationManager.AppSettings["UserAccount.CertID"];

                apiContext.ApiCredential = apiCredential;
                //set eBay Site target to US
                apiContext.Site = SiteCodeType.UK;

                //oContext.ApiCredential.ApiAccount.Developer = ""; // use your dev ID
                //oContext.ApiCredential.ApiAccount.Application = ""; // use your app ID
                //oContext.ApiCredential.ApiAccount.Certificate = ""; // use your cert ID
                return apiContext;
            }

        }

        static void GetEbayItem(string itemNumber)
        {
            Console.WriteLine("Hello");
            string itemId = "222366593223";

            ApiContext apiContext = GetApiContext();
            //[Step 2] Create Call object and execute the Call
            GeteBayOfficialTimeCall apiCall = new GeteBayOfficialTimeCall(apiContext);

            GetItemCall oGetItemCall = new GetItemCall(apiContext);

            //' set the Version used in the call
            oGetItemCall.Version = apiContext.Version;

            //' set the Site of the call
            oGetItemCall.Site = apiContext.Site;

            //' enable the compression feature
            oGetItemCall.EnableCompression = true;
            oGetItemCall.DetailLevelList.Add(eBay.Service.Core.Soap.DetailLevelCodeType.ReturnAll);
            oGetItemCall.ItemID = itemId;
            try
            {
                oGetItemCall.GetItem(oGetItemCall.ItemID);
            }
            catch (Exception E)
            {
                Console.Write(E.ToString());
                oGetItemCall.GetItem(itemId);
            }
            GC.Collect();
            var item = oGetItemCall;
        }
    }
}