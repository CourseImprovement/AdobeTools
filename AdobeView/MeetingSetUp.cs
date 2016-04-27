using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace AdobeView
{
    class MeetingSetUp
    {
        private string _cookie;
        private string _courseName;
        private string _scoId;
        private string _folderId;
        private string _meetingId;
        private string _section;
        private int _numberOfMeetings;

        /// <summary>
        /// Constructor for MeetingSetUp
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="courseName"></param>
        /// <param name="sections"></param>
        public MeetingSetUp(string cookie, string courseName, string section, int numMeetings)
        {
            _cookie = cookie;
            _courseName = courseName.Replace(" ", "_");
            _section = section;
            _numberOfMeetings = numMeetings;
        }

        /// <summary>
        /// Makes all http requests to adobe connect
        /// </summary>
        /// <param name="url"></param>
        /// <param name="callingFunction"></param>
        /// <returns>XML document</returns>
        private XmlDocument GetRequest(string url, string callingFunction)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                string attrVal = xmlDoc.SelectSingleNode("/results/status/@code").Value;

                if (attrVal != "ok")
                    throw new AdobeConnectMeetingException(callingFunction + ":", attrVal);

                return xmlDoc;
            }
            catch (AdobeConnectMeetingException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Main driving function
        /// </summary>
        public void CourseMeetingCreation()
        {
            bool found = false;
            string path = @"" + _cookie;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc = GetRequest(path, "course meeting creation");

            // parse xml for course name
            XmlNodeList itemRefList = xmlDoc.GetElementsByTagName("sco");
            foreach (XmlNode xn in itemRefList)
            {
                if (xn.FirstChild.InnerText == _courseName.ToUpper())
                {
                    _scoId = xn.Attributes["sco-id"].Value;
                    found = true;
                }
            }

            if (!found)
            {
                // the folder does not exist
                try
                {
                    string url = @""
                        + _courseName.ToUpper() + _cookie;

                    XmlDocument xmlDoc2 = new XmlDocument();
                    xmlDoc2 = GetRequest(url, "creating the course folder");

                    XmlNodeList item = xmlDoc2.GetElementsByTagName("sco");
                    _scoId = item[0].Attributes["sco-id"].Value;
                }
                catch (AdobeConnectMeetingException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            CreateSet(@"" + _scoId + "&sort-name=asc" + _cookie);
        }

        /// <summary>
        /// Create a set in the course folder
        /// </summary>
        /// <param name="url"></param>
        private void CreateSet(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc = GetRequest(url, "finding the list of sets");

            string set = (_section.Length < 2 ? "SET_0" : "SET_") + _section;

            XmlNodeList itemRefList = xmlDoc.GetElementsByTagName("sco");
            foreach (XmlNode xn in itemRefList)
            {
                if (xn.FirstChild.InnerText == set)
                {
                    return;
                }
            }

            string path2 = @""
                + (_section.Length < 2 ? "SET_0" : "SET_") + _section + "&folder-id=" + _scoId + "&depth=1" + _cookie;

            xmlDoc = GetRequest(path2, "creating a set");

            XmlNodeList item2 = xmlDoc.GetElementsByTagName("sco");
            _folderId = item2[0].Attributes["sco-id"].Value;

            CreateMeetings();
        }

        /// <summary>
        /// Creates multiples mettings within a given set
        /// </summary>
        private void CreateMeetings()
        {
            string set;

            if (_section.Length < 2)
                set = "G00" + _section;
            else if (_section.Length < 3)
                set = "G0" + _section;
            else
                set = "G" + _section;

            string name = _courseName.Replace("_", "") + "_" + set + "_";

            for (int i = 1; i <= _numberOfMeetings; i++)
            {
                string tag;

                if (i < 10)
                    tag = name + "00" + i;
                else if (i < 100)
                    tag = name + "0" + i;
                else
                    tag = name + i;

                string path = @""
                    + tag.ToUpper() + "&folder-id=" + _folderId + "&date-begin="
                    + DateTime.UtcNow.ToString("s") + "&date-end=" + DateTime.UtcNow.AddHours(1).ToString("s") + "&url-path=" + tag.ToLower()
                    + "&principal-id=public-access&permission-id=view-hidden" + _cookie;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc = GetRequest(path, "creating meeting" + i);

                XmlNodeList item = xmlDoc.GetElementsByTagName("sco");
                _meetingId = item[0].Attributes["sco-id"].Value;
                EnrollInstructor();
            }
        }

        /// <summary>
        /// Enrolls instructor into the room and sets them as the host
        /// </summary>
        private void EnrollInstructor()
        {
            string url1 = @"" + _meetingId + "&permission-id=host" + _cookie;
            string url2 = @"" + _meetingId + "&principal-id=public-access&permission-id=view-hidden" + _cookie;

            GetRequest(url1, "instructor hosting");
            GetRequest(url2, "setting accessibility");
        }
    }
}