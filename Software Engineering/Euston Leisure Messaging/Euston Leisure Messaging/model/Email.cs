using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
    public class Email : Message
    {
        private String subject;
        private String censor = "<URL QUarantined>";
        private ArrayList urlList;
        private String head;

        #region regex
        private Regex emailPattern = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);
      
        private Regex urlPattern = new Regex(@"^(https?|ftp|file)://[-a-zA-Z0-9+&@#/%?=~_|!:,.;]*[-a-zA-Z0-9+&@#/%=~_|]");
        
        #endregion


        #region constructors
        public Email(String head, String body)
            : base(head, body)
        {
            urlList = new ArrayList();
        }
        #endregion


        private void quarintineURL()
        {
            foreach(Match match in urlPattern.Matches(MessageText))
            {
                urlList.Add(match.Value);
            }

            String temp = urlPattern.Replace(MessageText, censor);
            MessageText = temp;
        }


        public void analyiseEmail()
        {
            String tempSender = Body.Split('\r')[0];

            Match match = emailPattern.Match(tempSender);
            if(match.Success)
            {
                Sender = tempSender;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Sender is invalid");
            }
            string tempSubject = MessageText.Split('\r')[0];
            if(tempSubject.Length <= 20)
            {
                subject = tempSubject;
                MessageText = MessageText.Substring(MessageText.IndexOf('\n') + 1);
            }
        }

















        #region getters and setters
        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public ArrayList URLList
        {
            get { return urlList; }
        }

        public String Head
        {
            get { return head; }
            set { head = value; }
        }


#endregion 






    }
}
