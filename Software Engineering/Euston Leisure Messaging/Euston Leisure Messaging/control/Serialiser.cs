using Euston_Leisure_Messaging.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.control
{
    class Serialiser
    {

        public static string serialiseMessage(Message msg)
        {
            return (JsonConvert.SerializeObject(msg));

        }



        public static void serialiseToFile(Message msg)
        {
            string json = JsonConvert.SerializeObject(msg);
            StreamWriter file = new StreamWriter("messages.txt", true);
            file.WriteLine(json);

            file.Close();
        }










    }
}
