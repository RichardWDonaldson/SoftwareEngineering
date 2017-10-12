using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
    public class Message
    {

        private String sender;
        private string head;
        private string body;
        private static Dictionary<string, string> TEXTSPEAK;


#region constructors
        public Message(string head, string body)
        {
            this.head = head;
            this.body = body;
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

        #endregion

        #region methods

        



        #endregion



    }
}
