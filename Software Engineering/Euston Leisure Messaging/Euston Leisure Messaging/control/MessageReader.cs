using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging.control
{
    class MessageReader
    {
        private String filePath;
        private List<String> messages;


        public MessageReader(String path)
        {
            filePath = path;
        }


        public void readMessage()
        {
            messages = new List<string>();
            int i = 0;

            try
            {
                StreamReader reader = new StreamReader(filePath);
                {
                    string line;

                    string temp = "";

                    while (reader.Peek() != -1)
                    {
                        line = reader.ReadLine();
                        if (!line.Equals(""))
                        {
                            temp += line + "\r\n";
                        }
                        else
                        {
                            messages.Add(temp);
                            temp = "";
                            i++;

                        }
                    }




                }
            }
            catch (Exception e)
            {
                throw (e);
            }




        }


    public List<string> Messages
        {
            get { return messages; }

        }












    }
}
