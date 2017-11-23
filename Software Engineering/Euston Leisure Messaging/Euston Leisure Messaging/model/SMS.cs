using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
  public class SMS : Message, IMessage
    {
        #region regex
        private Regex numberPattern = new Regex(@"^(((\+44\s ?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$");
#endregion

    

        #region constructors
        public SMS (String head, String body)
            :base(head,body)
        {
            
        }

        #endregion


        public void analyseMessage()
        {

            String temp = Body.Split('\r')[0];
           

            Match match = numberPattern.Match(temp);

            if(match.Success)
            {
                Sender = temp;

                MessageText = Body.Substring(Body.IndexOf('\n') + 1);
            }
            else
            {
                throw new ArgumentOutOfRangeException("SMS sender", "invalid");
            }

            if (MessageText.Length <= 140)
            {
                translateTextSpeak();
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("SMS body", "Invalid");
            }




        }


        #region toString
        public override String toString()
        {
            String output = "Type:\tSMS\nID:\t" + Head + "\nSender:\t" +
                Sender + "\nText:\n" + MessageText;
            return output;
        }

        #endregion

    }
}
