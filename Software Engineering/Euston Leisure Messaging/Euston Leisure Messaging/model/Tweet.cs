using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
   public class Tweet : Message, IMessage
    {

        #region regex
        private Regex userPattern = new Regex(@"@[a-zA-Z0-9]{1,15}");
        private Regex hashTagPattern = new Regex(@"#[a-zA-Z0-9]+");
#endregion


        #region constructors
        public Tweet(String head, String body)
            :base(head,body)
        {

        }

        #endregion


        #region getters and setters


        #endregion


        public void analyseMessage()
        {
            String temp = Body.Split('\r')[0];

            Match match = userPattern.Match(temp);

            if (match.Success)
            {
                Sender = temp;
                MessageText = Body.Substring(Body.IndexOf('\n') + 1);
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Tweet", "Invalid Tweet sent");
            }

            if (MessageText.Length <= 140)
            {
                findHashTags();
                findMentions();
                translateTextSpeak();
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Tweet", "Invalid Tweet body");
            }








        }


        public void findHashTags()
        {
            foreach (Match match in hashTagPattern.Matches(MessageText)) {
                Control.addHashTag(match.Value);
            }
        }


        public void findMentions()
        {
            foreach(Match match in userPattern.Matches(MessageText))
            {
                Control.addMention(match.Value);
            }

        }


        #region toString
        public override String toString()
        {
            String output = "Type:\tTweet\nID:\t" + Head + "\nSender:\t" +
                Sender + "\nText:\n" + MessageText;
            return output;
        }

        #endregion

    }
}
