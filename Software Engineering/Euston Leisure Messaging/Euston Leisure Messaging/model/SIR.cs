using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
    public class SIR : Email
    {
        private String centreCode;
        private String incident;
        private static ArrayList INCIDENTS;


        private static Regex subjectPattern = new Regex(@"SIR (3[01]|[12][0-9]|0?[1-9])\/(1[0-2]|0?[1-9])\/(?:[0-9]{2})?[0-9]{2}");


        #region constructors
        public SIR(Email email)
        {
            this.Head = email.Head;
            this.Body = email.Body;
            this.Sender = email.Sender;
            this.Subject = email.Subject;
           
        }
        #endregion


        #region getters and setters
        public String CentreCode
        {
            get { return centreCode; }
            set { centreCode = value; }
        }


        public String Incident
        {
            get { return incident; }
            set { Incident = value; }
        }
#endregion



    }
}
