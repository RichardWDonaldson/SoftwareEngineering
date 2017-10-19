using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    class Control
    {
        private string header;
        private string body;
        private string output;


        private static Dictionary<String, Int32> HASHTAG_DICTIONARY;
        private static Dictionary<String, Int32> MENTION_DICTIONARY;
        private static Dictionary<String, Int32> SIR_DICTIONARY;

        private Regex idPattern = new Regex(@"[A-Z]\d{9}");

        private static ArrayList URL_LIST;
        private static ArrayList MESSAGE_LIST;


        #region constructor
        public Control()
        {
            HASHTAG_DICTIONARY = new Dictionary<String, Int32>();
            MENTION_DICTIONARY = new Dictionary<String, Int32>();
            SIR_DICTIONARY = new Dictionary<String, Int32>();
            URL_LIST = new ArrayList();
            MESSAGE_LIST = new ArrayList();
        }
        #endregion

        public void analyseMessage(String inputHead, String inputBody)
        {
            header = inputHead;
            body = inputBody;
            Match match = idPattern.Match(header);
        }



        #region getters and setters
        public String Header {

            get { return header; }
            set { header = value; }


        }

        public String Body
        {
            get { return body; }
            set { body = value; }
        }


        public String Output
        {
            get { return output; }
            set { output = value; }
        }




#endregion









    }
}


    

