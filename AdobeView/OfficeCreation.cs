using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace AdobeView
{
    class OfficeCreation
    {
        private string _cookie;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _officeName;
        private string _scoId;

        /// <summary>
        /// Constructor for office creation
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="email"></param>
        public OfficeCreation(string cookie, string first, string last, string email)
        {
            try
            {
                if (cookie == "")
                    throw new AdobeConnectException("ERROR: Cookie invalid, please login");

		        if (first.Length < 1 || last.Length < 1 || email.Length < 1) 
                    throw new AdobeConnectException("ERROR: Input information is missing");

                if (email.IndexOf('@') == -1)
                    throw new AdobeConnectException("ERROR: Email not valid");
            }
            catch (AdobeConnectException e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                throw e;
            }

            _cookie = cookie;
            _firstName = first;
            _lastName = last;
            _email = email;
            _officeName = email.Split('@')[0].ToUpper();
	    }

        /// <summary>
        /// Checks if the office is already created
        /// </summary>
        /// <returns></returns>
	    public bool IsCreated()
        {
            // Check if user exists
            try
            {
                string url = @"" + _officeName + _cookie;
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());

                string attrVal = xmlDoc.SelectSingleNode("/results/status/@code").Value;

                if (attrVal == "ok")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (AdobeConnectException e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                throw e;
            }
	    }

        public void CreateAccount()
        {
            string url = @"" + _firstName + "&last-name=" + _lastName + "&login=" + _email + "&password=byuitemp123&type=user&send-email=true&has-children=0&email=" + _email + _cookie;
            string pid = "";
            string url2 = @"";
            // Check if user exists
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());

                pid = xmlDoc.SelectSingleNode("/results/principal/@principal-id").Value;
            }
            catch (AdobeConnectException e)
            {
                throw e;
            }

            try
            {
                HttpWebRequest request = WebRequest.Create(url2 + pid + _cookie) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
            }
            catch (AdobeConnectException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Creates the instructor office
        /// </summary>
        public void CreateOffice()
        {
            string officePath = _officeName.ToLower();
            string url = @""
                + _officeName + "&folder-id=1078384522&date-begin=" + DateTime.UtcNow.ToString("s") + "Z"
                + "&date-end=" + DateTime.UtcNow.AddHours(1).ToString("s") + "Z" + "&url-path=" + officePath
                + "&principal-id=public-access&permission-id=view-hidden" + _cookie;

            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                string attrVal = xmlDoc.SelectSingleNode("/results/status/@code").Value;

                if (attrVal != "ok")
                    throw new AdobeConnectException("function CreateOffice", attrVal);

                _scoId = xmlDoc.SelectSingleNode("results/sco/@sco-id").Value;
            }
            catch (AdobeConnectException e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                throw e;
            }
        }

        /// <summary>
        /// Create the instructor meeting and set the instructor as 
        /// </summary>
        public void CreateMeetings()
        {
            string url = @"" + _scoId + "&permission-id=host" + _cookie;
            string url2 = @"" + _scoId + "&principal-id=public-access&permission-id=view-hidden" + _cookie;

            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                string attrVal = xmlDoc.SelectSingleNode("/results/status/@code").Value;

                if (attrVal != "ok")
                    throw new AdobeConnectException("function CreateMeetings, first url", attrVal);
            }
            catch (AdobeConnectException e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                throw e;
            }

            try
            {
                HttpWebRequest request = WebRequest.Create(url2) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                string attrVal = xmlDoc.SelectSingleNode("/results/status/@code").Value;

                if (attrVal != "ok")
                    throw new AdobeConnectException("function CreateMeetings, second url", attrVal);
            }
            catch (AdobeConnectException e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                throw e;
            }
        }
    }
}