using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string line;

            string temp = "";
            try
            {
                StreamReader reader = new StreamReader(filePath);


                Debug.WriteLine("peak" + reader.Peek());
                    while (reader.Peek() != -1)
                    {
                        line = reader.ReadLine();
                        if (!line.Equals(""))
                        {
                            temp += line + "\r\n";
                        }
                        else
                        {
                            Debug.WriteLine(temp);
                            Debug.WriteLine(i);
                            messages.Add(temp);
                            temp = "";
                        i++;
                        Debug.WriteLine(i);

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
