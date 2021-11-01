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
                    number = 0;
                }
                else
                {
                    string latestFileName = listOfFileNames.Last();
                    number = Convert.ToInt32(latestFileName.Substring(latestFileName.Length - 5, 1)); // Hämtar de fem sista tecknen i sökvägen och sparar det första tecknet av de fem, vilket kommer vara en siffra.
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
