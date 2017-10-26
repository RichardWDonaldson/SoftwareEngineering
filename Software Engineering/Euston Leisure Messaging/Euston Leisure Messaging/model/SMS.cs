using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
  public class SMS : Message
    {
        #region regex
        private Regex numberPattern = new Regex(@"\+(9[976]\d|8[987530]
                                                \d|6[987]\d|5[90]\d|42\d|3[875]
                                                \d|2[98654321]
                                                \d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)
                                                \d{1,14}$");
#endregion

    

        #region constructors
        public SMS (String head, String body)
            :base(head,body)
        {
            
        }

        #endregion


        public void analyiseSMS()
        {
            String temp = Body.Split('r')[0];

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





        #region getters and setters 

        #endregion

        #region toString
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion



    }
}
