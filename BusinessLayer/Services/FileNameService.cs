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
                return e.Message;
            }
            return fileName;
        }

        public List<string> GetFileNameList()
        {
             string localPath = Directory.GetCurrentDirectory();
            List<string> fileNames = Directory.GetFiles(localPath, "feed*.xml").ToList();
            return fileNames;
        }
    }
}
