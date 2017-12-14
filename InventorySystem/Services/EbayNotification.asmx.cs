using eBay.Service.Core.Soap;
using System;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.Services;

namespace InventorySystem.Services
{
    /// <summary>
    /// Summary description for EbayNotification
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    [WebService(Namespace = "urn:ebay:apis:eBLBaseComponents")]
    public class EbayNotification : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }



        private CustomSecurityHeaderType mRequesterCredentials;

        public EbayNotification()
        {
            //CODEGEN: This call is required by the ASP.NET Web Services Designer
            InitializeComponent();

        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }

        //Required by the Web Services Designer 
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/AskSellerQuestion", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void AskSellerQuestion(GetMemberMessagesResponseType GetMemberMessagesResponse)
        //{
        //    if (CheckSignature(GetMemberMessagesResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/AskSellerQuestion_" + GetMemberMessagesResponse.MemberMessage[0].Item.ItemID + "_" + GetMemberMessagesResponse.MemberMessage[0].Question.MessageID + "_" + GetMemberMessagesResponse.CorrelationID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/AuctionCheckoutComplete", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void AuctionCheckoutComplete(GetItemTransactionsResponseType GetItemTransactionsResponse)
        //{
        //    if (CheckSignature(GetItemTransactionsResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/AuctionCheckoutComplete_" + GetItemTransactionsResponse.Item.ItemID + "_" + GetItemTransactionsResponse.CorrelationID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/BestOffer", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void BestOffer(GetBestOffersResponseType GetBestOffersResponse)
        //{

        //    if (CheckSignature(GetBestOffersResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/BestOffer_" + GetBestOffersResponse.Item + "_" + GetBestOffersResponse.BestOfferArray[0].BestOfferID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/CheckoutBuyerRequestsTotal", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void CheckoutBuyerRequestsTotal(GetItemTransactionsResponseType GetItemTransactionsResponse)
        //{
        //    if (CheckSignature(GetItemTransactionsResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/CheckoutBuyerRequestsTotal_" + GetItemTransactionsResponse.Item.ItemID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/EndOfAuction", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void EndOfAuction(GetItemTransactionsResponseType GetItemTransactionsResponse)
        //{
        //    if (CheckSignature(GetItemTransactionsResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/EndOfAuction_" + GetItemTransactionsResponse.Item.ItemID + "_" + GetItemTransactionsResponse.RecipientUserID + "_" + GetItemTransactionsResponse.CorrelationID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/Feedback", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void Feedback(GetFeedbackResponseType GetFeedbackResponse)
        //{
        //    if (CheckSignature(GetFeedbackResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/Feedback_" + GetFeedbackResponse.FeedbackDetailArray[0].ItemID + "_" + GetFeedbackResponse.RecipientUserID + "_" + GetFeedbackResponse.CorrelationID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/FeedbackBySeller", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void FeedbackBySeller(GetFeedbackResponseType GetFeedbackResponse)
        //{
        //    if (CheckSignature(GetFeedbackResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/FeedbackBySeller_" + GetFeedbackResponse.FeedbackDetailArray[0].ItemID + "_" + GetFeedbackResponse.RecipientUserID + "_" + GetFeedbackResponse.CorrelationID + ".xml"));
        //}


        [WebMethod()]
        [System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/FixedPriceEndOfTransaction", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        public void FixedPriceEndOfTransaction(GetItemTransactionsResponseType GetItemTransactionsResponse)
        {
            //if (CheckSignature(GetItemTransactionsResponse.Timestamp))
            //{
            //    //Implement your own business logic here
            //}
            //else
            //{
            //    //Implement your own business logic here

            //}
            LogRequest(Server.MapPath("../files/FixedPriceEndOfTransaction_" + GetItemTransactionsResponse.Item.ItemID + "_" + GetItemTransactionsResponse.CorrelationID + ".xml"));
        }

        [WebMethod()]
        [System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/FixedPriceTransaction", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        public void FixedPriceTransaction(GetItemTransactionsResponseType GetItemTransactionsResponse)
        {
            //if (CheckSignature(GetItemTransactionsResponse.Timestamp))
            //{
            //    //Implement your own business logic here
            //}
            //else
            //{
            //    //Implement your own business logic here
            //}
            LogRequest(Server.MapPath("../files/FixedPriceTransaction_" + GetItemTransactionsResponse.Item.ItemID + "_" + GetItemTransactionsResponse.CorrelationID + ".xml"));
        }

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/OutBid", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void OutBid(GetItemResponseType GetItemResponse)
        //{
        //    if (CheckSignature(GetItemResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/OutBid_" + GetItemResponse.Item.ItemID + "_" + GetItemResponse.Item.SellingStatus.BidCount.ToString() + "_" + GetItemResponse.CorrelationID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/SellerOpenedDispute", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void SellerOpenedDispute(GetDisputeResponseType GetDisputeResponse)
        //{
        //    if (CheckSignature(GetDisputeResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/SellerOpenedDispute_" + GetDisputeResponse.Dispute.Item.ItemID + "_" + GetDisputeResponse.CorrelationID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/SellerRespondedToDispute", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void SellerRespondedToDispute(GetDisputeResponseType GetDisputeResponse)
        //{
        //    if (CheckSignature(GetDisputeResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/SellerRespondedToDispute_" + GetDisputeResponse.Dispute.Item.ItemID + "_" + GetDisputeResponse.CorrelationID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/BuyerResponseToDispute", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void BuyerResponseToDispute(GetDisputeResponseType GetDisputeResponse)
        //{
        //    if (CheckSignature(GetDisputeResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/BuyerResponseToDispute_" + GetDisputeResponse.Dispute.Item.ItemID + "_" + GetDisputeResponse.CorrelationID + ".xml"));
        //}

        //[WebMethod()]
        //[System.Web.Services.Protocols.SoapHeaderAttribute("RequesterCredentials", Direction = System.Web.Services.Protocols.SoapHeaderDirection.In)]
        //[System.Web.Services.Protocols.SoapDocumentMethodAttribute(Action = "http://developer.ebay.com/notification/SellerClosedDispute", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        //public void SellerClosedDispute(GetDisputeResponseType GetDisputeResponse)
        //{
        //    if (CheckSignature(GetDisputeResponse.Timestamp))
        //    {
        //        //Implement your own business logic here
        //    }
        //    else
        //    {
        //        //Implement your own business logic here
        //    }
        //    LogRequest(Server.MapPath("files/SellerClosedDispute_" + GetDisputeResponse.Dispute.Item.ItemID + "_" + GetDisputeResponse.CorrelationID + ".xml"));
        //}

        private bool CheckSignature(DateTime TimeStamp)
        {
            const string AppId = "myappname";
            const string DevId = "mydevname";
            const string AuthCert = "mycertname";

            string sig = TimeStamp.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + DevId + AppId + AuthCert;
            byte[] sigdata = System.Text.Encoding.ASCII.GetBytes(sig);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string md5Hash = System.Convert.ToBase64String(md5.ComputeHash(sigdata));


            // Remove
            FileStream fileStream = null;
            StreamWriter writer = null;
            fileStream = new FileStream(Server.MapPath("files/SigCheck.txt"), FileMode.OpenOrCreate, FileAccess.Write);
            using (writer = new StreamWriter(fileStream))
            {
                // Set the file pointer to the end of the file
                writer.BaseStream.Seek(0, SeekOrigin.End);

                // Force the write to the underlying file
                writer.WriteLine("Signiature: " + mRequesterCredentials.NotificationSignature);
                writer.WriteLine("Computed: " + md5Hash);
                if (mRequesterCredentials.NotificationSignature == md5Hash && DateTime.Now.Subtract(TimeStamp).Duration().TotalMinutes <= 10)
                    writer.WriteLine("PASSED");
                else
                    writer.WriteLine("FAILED");

                writer.WriteLine();
                writer.Flush();
                if (writer != null) writer.Close();
            }
            // End Remove


            return (mRequesterCredentials.NotificationSignature == md5Hash);

        }

        /// <summary>
        /// Write the raw request to a file.
        /// </summary>
        /// <param name="FileName">The file to write the request to.</param>
        private void LogRequest(string FileName)
        {
            HttpContext.Current.Request.InputStream.Position = 0;
            Stream str = HttpContext.Current.Request.InputStream;
            StreamReader sr = new StreamReader(str);
            string msg = sr.ReadToEnd();
            sr.Close();
            str.Close();

            FileStream fileStream = null;
            StreamWriter writer = null;

            if (File.Exists(FileName))
            {
                string file = FileName.Substring(0, FileName.Length - 4);
                int x = 1;
                bool fnd = false;
                do
                {
                    if (!File.Exists(file + "_" + x.ToString()))
                    {
                        FileName = file + "_" + x.ToString() + ".xml";
                        fnd = true;
                    }
                } while (!fnd);
            }


            fileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            using (writer = new StreamWriter(fileStream))
            {
                // Set the file pointer to the end of the file
                writer.BaseStream.Seek(0, SeekOrigin.End);

                // Force the write to the underlying file
                writer.WriteLine(msg);
                writer.Flush();
                if (writer != null) writer.Close();
            }
        }


        /// <summary>
        /// Property to hold the Soap header.
        /// </summary>
        public CustomSecurityHeaderType RequesterCredentials
        {
            get
            {
                return this.mRequesterCredentials;
            }
            set
            {
                this.mRequesterCredentials = value;
            }
        }
    }
}
