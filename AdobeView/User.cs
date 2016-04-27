using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace AdobeView
{
    class User
    {
        private string _userName;
        private string _password;
        private string _cookie;

        public User(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public bool Authenticate()
        {
            FindCookie();

            string url = @"" + _userName + "&password=" + _password + _cookie;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());

            string attrVal = xmlDoc.SelectSingleNode("/results/status/@code").Value;

            if (attrVal != "ok")
                return false;
            else
                return true;
        }

        private void FindCookie()
        {
            HttpWebRequest request = WebRequest.Create(@"") as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());

            _cookie = "&session=" + xmlDoc.SelectSingleNode("/results/common/cookie").InnerXml;
        }

        public string GetCookie()
        {
            return _cookie;
        }
    }
}