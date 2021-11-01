using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BusinessLayer.Services
{
    public class FileNameService
    {
        public string SetNewFileName()
        {       
            int number;
            string fileName;

            try
            {
                List<string> listOfFileNames = GetFileNameList();
                if (listOfFileNames.Count == 0)
                {
                    number = 10;
                }
                else
                {
                    string latestFileName = listOfFileNames.Last();
                    number = Convert.ToInt32(latestFileName.Substring(latestFileName.Length - 6, 2)); // Hämtar de sex sista tecknen i sökvägen och sparar de två första tecknen, vilket kommer vara en siffra mellan 10-99.
                    number++;
                }
                fileName = "feed" + Convert.ToString(number) + ".xml";
            } catch (Exception e)
            {
                return e.Message;
            }
            return fileName;
        }

        public List<string> GetFileNameList()
        {
            string localPath = Directory.GetCurrentDirectory(); // Hämtar sökvägen till applikationens solution på användarens dator.
            List<string> listOfFileNames = Directory.GetFiles(localPath, "feed*.xml").ToList(); // Hämtar alla xml-filer via sökvägen vars namn innehåller "feed".

            return listOfFileNames;
        }
    }
}
