using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using Models.Classes;
using Models;
using System.IO;

namespace BusinessLayer.Services
{
    public class FileNameService
    {
        public string SetNewFileName()
        {
            int number;
            string fileName;
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

            return fileName;
        }

        public List<string> GetFileNameList()
        {
            string localPath = Directory.GetCurrentDirectory();
            List<string> fileNames = Directory.GetFiles(localPath, "feed*.xml").ToList();
            //List<string> fileNames = Directory.GetFiles(@"C:\Users\moahe\OneDrive\Dokument\GitHub\RssApplication\RssApplication\bin\Debug", "*.xml").ToList();

            return fileNames;

        }
    }
}
