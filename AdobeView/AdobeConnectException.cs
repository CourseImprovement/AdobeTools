using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdobeView
{
    class AdobeConnectException : System.Exception
    {
        public AdobeConnectException() : base() { }

        public AdobeConnectException(string message) : base(message) { }

        public AdobeConnectException(string location, string code)
            : base(String.Format("\nAdobe Connect returned the following response in {0}: {1}", location, code)) { }

        protected AdobeConnectException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}