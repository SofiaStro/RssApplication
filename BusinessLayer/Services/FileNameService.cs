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
<<<<<<< Updated upstream

            try
=======
            List<string> listOfFileNames = GetFileNameList();
            if (listOfFileNames.Count == 0)
>>>>>>> Stashed changes
            {
                List<string> listFileNames = GetFileNameList();
                if (listFileNames.Count == 0)
                {
                    number = 0;
                }
                else
                {
                    string latestFileName = listFileNames.Last();
                    number = Convert.ToInt32(latestFileName.Substring(latestFileName.Length - 5, 1));
                    number++;
                }
                fileName = "feed" + Convert.ToString(number) + ".xml";
            } catch (Exception e)
            {
<<<<<<< Updated upstream
                return e.Message;
=======
                string latestFileName = listOfFileNames.Last();
                number = Convert.ToInt32(latestFileName.Substring(latestFileName.Length - 5, 1));
                number++;
>>>>>>> Stashed changes
            }
            return fileName;
        }

        public List<string> GetFileNameList()
        {
<<<<<<< Updated upstream
             string localPath = Directory.GetCurrentDirectory();
            List<string> fileNames = Directory.GetFiles(localPath, "feed*.xml").ToList();
            return fileNames;
=======
            string localPath = Directory.GetCurrentDirectory();
            List<string> listOfFileNames = Directory.GetFiles(localPath, "feed*.xml").ToList();

            return listOfFileNames;

>>>>>>> Stashed changes
        }
    }
}
