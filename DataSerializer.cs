using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DT071G_project
{
    class DataSerializer
    {
        string favoritesFilePath = @"favorits.json";

        //serilize favorite music
        public void JsonSerializeFavorits(List<FavoriteMusic> favoriteMusicList)
        {
            //check if json file eist and create if it dosen´t exist
            if (!File.Exists(favoritesFilePath))
            {
                FileStream fs = File.Create(favoritesFilePath);
            }

            //serialise data
            string jsonData = JsonConvert.SerializeObject(favoriteMusicList);
            System.IO.File.WriteAllText(favoritesFilePath, jsonData);
        }

        //deserilize favorite music
        public List<FavoriteMusic> JsonDeserializeFavorits()
        {
            //check if json file eist and create if it dosen´t exist
            if (!File.Exists(favoritesFilePath))
            {
                return new List<FavoriteMusic>();
            }
            else
            {
                //read json file
                var jsonData = System.IO.File.ReadAllText(favoritesFilePath);

                // Deserialise json file to C# object and create list
                var favoriteMusicList = JsonConvert.DeserializeObject<List<FavoriteMusic>>(jsonData)
                ?? new List<FavoriteMusic>();

                //return list
                return favoriteMusicList;

            }

        }

    }
}
