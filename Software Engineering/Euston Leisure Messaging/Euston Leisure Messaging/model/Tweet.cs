using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.model
{
   public class Tweet : Message
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


        #region toString
        public override string ToString()
        {
            return base.ToString();
        }

#endregion

    }
}
