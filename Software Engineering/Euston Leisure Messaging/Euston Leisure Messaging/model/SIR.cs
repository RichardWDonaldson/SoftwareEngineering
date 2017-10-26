using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        private static Regex centrePattern = new Regex(@"\b\d\d-\d\d-\d\d\b");

        #region constructors
        public SIR(Email email)
        {
            this.Head = email.Head;
            this.Body = email.Body;
            this.Sender = email.Sender;
            this.Subject = email.Subject;
            this.MessageText = email.MessageText;
           
        }
        #endregion

        public static void populateIncidents()
        {
            INCIDENTS = new ArrayList();

            StreamReader reader = new StreamReader("incidents.txt");
            {
                string line;

                while (reader.Peek() != -1)
                {
                    line = reader.ReadLine();
                    INCIDENTS.Add(line);
                }
            }
        }


        public static Boolean checkIfSir(Email email)
        {
            Match match = subjectPattern.Match(email.Subject);
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        public new void analyiseSIR()
        {
            String tempCentre = MessageText.Split('\r')[0];
            Match match = centrePattern.Match(tempCentre);

            if(match.Success)
            {
                centreCode = tempCentre;
                MessageText = MessageText.Substring(MessageText.IndexOf('\n') + 1);
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("SIR centre code", "invalidd");
            }
            String tempIncident = MessageText.Split('\r')[0];
            if(INCIDENTS.Contains(tempIncident))
            {
                incident = tempIncident;
                MessageText = MessageText.Substring(MessageText.IndexOf('\n') + 1);
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Sir incident", "invalid");
            }

            String concatSIR = centreCode + ", " + incident;

            Control.addSIR(concatSIR);







        }









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
