using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Classes;

namespace DataAccessLayer.Repositories
{
    public class FeedRepository : IFeedRepository<Feed>
    {
        SerializerForXml serializerObject;
        
        public FeedRepository()
        {
            serializerObject = new SerializerForXml();
        }

        public async Task SaveFeedAsync(Feed feedObject, string fileName)
        {
            await serializerObject.SerializerAsync(feedObject, fileName);
        }

        public async Task<List<Feed>> GetListOfFeedsAsync(List<string> listFileNames)
        {
            List<Feed> listOfFeedsDeserialized = new List<Feed>();
            try
            {
                List<string> fileNames = listFileNames;

                foreach (string fileName in listFileNames)
                {
                    listOfFeedsDeserialized.Add(await serializerObject.DeserializeAsync(fileName));
                }
            }
            catch (Exception) {}
            return listOfFeedsDeserialized;
        }

        public async Task<Feed> GetFeedObjectAsync(string fileName)
        {
            Feed feedObject = null;

            try
            {
                feedObject = await serializerObject.DeserializeAsync(fileName);
            }
            catch (Exception) {}
            return feedObject;
        }
    }
}
