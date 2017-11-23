using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
    public class Email : Message, IMessage
    {
        private String subject;
        private String censor = "<URL QUarantined>";
        private ArrayList urlList;
        private String head;

        #region regex
        private Regex emailPattern = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);
      
        private Regex urlPattern = new Regex(@"(((http|ftp|https):\/{2})+(([0-9a-z_-]+\.)+(aero|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cu|cv|cx|cy|cz|cz|de|dj|dk|dm|do|dz|ec|ee|eg|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|mk|ml|mn|mn|mo|mp|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|nom|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ra|rs|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sj|sk|sl|sm|sn|so|sr|st|su|sv|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw|arpa)(:[0-9]+)?((\/([~0-9a-zA-Z\#\+\%@\.\/_-]+))?(\?[0-9a-zA-Z\+\%@\/&\[\];=_-]+)?)?))\b");

        #endregion


        #region constructors
        public Email() { }

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


        public void analyseMessage()
        {
            String tempSender = Body.Split('\r')[0];

            Match match = emailPattern.Match(tempSender);
            if(match.Success)
            {
                Sender = tempSender;
                MessageText = Body.Substring(Body.IndexOf('\n') + 1);
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
            else
            {
                throw new System.ArgumentOutOfRangeException("Email Subject", "Email subject is too long.\nMust be under 20 chars.");
            }
            //chaeck remaining lenght of text
            if (MessageText.Length <= 1028)
            {
                //remove urls
                quarintineURL();
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Email Text", "Email text is too long.");
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

       


        #endregion

        #region toString

        public  override String toString()
        {
            String output = "Type:\tEmail\nID:\t" +Head + "\nSender:\t" +
                Sender + "\nSubject:\t" + Subject + "\nText:\n" + MessageText;
            return output;
        }

#endregion


    }
}
