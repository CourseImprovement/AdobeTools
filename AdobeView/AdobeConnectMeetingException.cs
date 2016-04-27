using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdobeView
{
    class AdobeConnectMeetingException : System.Exception
    {
        public AdobeConnectMeetingException() : base() { }

        public AdobeConnectMeetingException(string message) : base(message) { }

        public AdobeConnectMeetingException(string location, string code)
            : base(String.Format("Adobe Connect returned the following response in {0} {1}", location, code)) { }

        protected AdobeConnectMeetingException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}