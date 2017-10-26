using Euston_Leisure_Messaging.model;
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
        private Message output;


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


        #region methods
        public void analyseMessage(String inputHead, String inputBody)
        {
            header = inputHead;
            body = inputBody;

            try
            {

                Match match = idPattern.Match(header);

            }
            catch (System.ArgumentOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
                throw new System.ArgumentOutOfRangeException("Error in Header \n Must contain a Character and Nine Digits");
            }

            Char id = header[0];
            switch (id)
            {

                case 'E':
                    Email newMsg = new Email(header, body);
                    newMsg.analyiseEmail();
                    output = newMsg;
                    if (SIR.checkIfsir(newMsg))
                    {
                        SIR.fillIncidents();
                        SIR sir = new SIR(newMsg);
                        output = sir;
                    }
                    break;

                case 'S':
                    SMS newMsg = new SMS(header, body);
                    newMsg.analyiseSMS();
                    output = newMsg;
                    break;

                case 'T':
                    Tweet newMsg = new Tweet(header, body);
                    newMsg.analyiseTweet();
                    output = newMsg;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Error in ID");
                    break;
            }

            MESSAGE_LIST.Add(output);
            control.Serialiser.serialiseToFile(output);

        }
        #endregion


        #region add to dictionary
        public static void addHashTag(String hash)
        {
            if (HASHTAG_DICTIONARY.ContainsKey(hash))
            {
                HASHTAG_DICTIONARY[hash] += 1;
            }
            else
            {
                HASHTAG_DICTIONARY.Add(hash, 1);
            }
        }

        public static void addSIR(string sir)
        {
            if (SIR_DICTIONARY.ContainsKey(sir))
            {
                SIR_DICTIONARY[sir] += 1;
            } else
            {
                SIR_DICTIONARY.Add(sir, 1);
            }
        }

        public static void addMention(String mention)
        {
            if (MENTION_DICTIONARY.ContainsKey(mention))
            {
                MENTION_DICTIONARY[mention] += 1;
            }
            else
            {
                MENTION_DICTIONARY.Add(mention, 1);
            }

        }

        public static void addURL(String url)
        {
            URL_LIST.Add(url);
        }

        #endregion


        #region getters and setters
        public String Header
        {

            get { return header; }
            set { header = value; }
        }

        public String Body
        {
            get { return body; }
            set { body = value; }
        }

        public Message Output
        {
            get { return output; }
            set { output = value; }
        }

        public static Dictionary<String, Int32> Dictionary_HashTag
        {
            get { return Control.HASHTAG_DICTIONARY; }

        }

        public static Dictionary<String, Int32> Dictionary_Mention
        {
            get { return Control.MENTION_DICTIONARY; }
        }

        public static Dictionary<String, Int32> Dictionary_SIR
        {
            get { return Control.SIR_DICTIONARY; }

        }

        public static ArrayList MessageList
        {
            get { return Control.MESSAGE_LIST; }
        }

        public static ArrayList UrlList
        {
            get { return Control.URL_LIST; }
        }

        #endregion

    }
}



    

