using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
    public abstract class Message
    {

        private string sender;
        private string head;
        private string body;
        private string messageText;
        private static Dictionary<string, string> TEXTSPEAK;


        #region constructors

        public Message() { }
        public Message(string head, string body)
        {
            this.head = head;
            this.body = body;
        }


        #endregion

        #region methods

        public static void populateTextSpeak()
        {
            TEXTSPEAK = new Dictionary<string, string>();

            StreamReader reader = new StreamReader("textwords.csv");
            {
                string line;
                while (reader.Peek() != -1)
                {
                    line = reader.ReadLine();
                    string[] split = line.Split(',');
                    TEXTSPEAK.Add(split[0], split[1]);
                }



            }
        }

        public void translateTextSpeak()
        {
            string input = messageText;

            foreach(KeyValuePair<String, String> key in TEXTSPEAK)
            {
                Regex pat = new Regex(@"\b" + key.Key + "\\b");

                input = pat.Replace(input, key.Key + "<" + key.Value + ">");

            }
            messageText = input;
        }






        #endregion


        #region getters and setters
        public String Head
        {
            get { return head; }
            set { head = value; }
        }

        public String Body
        {
            get { return body; }
            set { head = value; }
        }

        public String Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        public String MessageText
        {
            get { return messageText; }
            set { messageText = value; }
        }


        #endregion

        //method to display message strings
        public virtual String toString()
        {
            return null;
        }



    }
}
