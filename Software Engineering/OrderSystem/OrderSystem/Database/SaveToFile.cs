using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OrderSystem.Models;

namespace OrderSystem.Database
{
    public class SaveToFile
    {
        private string _csvFilePath;

        public string ErrorCode { get; set; }

        public SaveToFile()
        {
            _csvFilePath = "<<< ENTER YOUR FILE PATH TO CSV HERE >>";


            ErrorCode = string.Empty;
        }

        public bool ToCsv(Order order)
        {
            try
            {
                string csv = $"{order.Name},{order.Price.ToString()},{order.IsPaid.ToString()}";
                csv = csv + Environment.NewLine;
                File.AppendAllText(_csvFilePath, csv.ToString());
                return true;
            }
            catch(Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }


    }
}
