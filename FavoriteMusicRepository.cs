using System;
using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;

namespace DT071G_project
{
    class FavoriteMusicRepository
    {
        public void AddFavoriteMusic(FavoriteMusic favoriteMusic)
        {
            //create instance of class DataSerialzer
            var serialize = new DataSerializer();

            //get json-file as a list
            var favoriteMusicList = serialize.JsonDeserializeFavorits();

            //add object to list
            favoriteMusicList.Add(favoriteMusic);

            //serialise postList again to json format
            serialize.JsonSerializeFavorits(favoriteMusicList);
        }

        public bool DeleteFavoriteMusic(int index) //bool- istället om false felmeddelande, true är ok 
        {
            //create instance of class DataSerialzer
            var serialize = new DataSerializer();


            try //try if input is correct
            {
                //deserialze json and get a list of all post objects
                var favoriteMusicList = serialize.JsonDeserializeFavorits();

                //delete object where index = index
                favoriteMusicList.RemoveAt(index);

                //serialize to json again
                serialize.JsonSerializeFavorits(favoriteMusicList);

                return true;
            }
            // if input does not exist in the list
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        public List<FavoriteMusic> GetFavoriteMusic()
        {
            //create instance of class DataSerialzer
            var serialize = new DataSerializer();

            //deserialze json and get a list of all post objects
            var favoriteMusicList = serialize.JsonDeserializeFavorits();

            return favoriteMusicList;
        }

        public void showMusic()
        {
            FavoriteMusicRepository favoriteMusicRepository = new FavoriteMusicRepository();
            //clear console
            Console.Clear();
            Console.WriteLine("Dina favoritlåtar", Color.DeepPink);
            Console.WriteLine("==========================\n", Color.DeepPink);

            int i = 0;
            foreach (FavoriteMusic favoriteMusics in favoriteMusicRepository.GetFavoriteMusic())
            {
                Console.WriteLine($"[{i}] {favoriteMusics.Artist} - {favoriteMusics.SongName}\n", Color.Beige);
                i++;
            }
        }
    }
}
