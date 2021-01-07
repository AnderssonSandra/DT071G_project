using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing;
using Console = Colorful.Console;

namespace DT071G_project
{
    class Api
    {
        //Class to get songs from spotify api
        public void GetData(string input)
        {
            //get new authorization token
            string authToken = GetToken();

            //create instance of class
            HttpClient client = new HttpClient();

            //base adress
            client.BaseAddress = new Uri("https://api.spotify.com/v1/search");

            //define headers
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            HttpResponseMessage response = client.GetAsync("?q=" + input + "&type=track").Result;
            if (response.IsSuccessStatusCode)
            {
                //save data in string
                string jsonData = response.Content.ReadAsStringAsync().Result;
                //serialize json data to c# object
                var searchResult = JsonConvert.DeserializeObject<SearchResult>(jsonData);

                Console.Clear();
                string searchInput = input.Replace('+', ' ');
                showSearchResult(searchInput, searchResult);
            }
            else
            {
                Console.Clear();
                //write error message
                Console.WriteLine("\nHoppas! Nu gick det inte att hämta sökresutatet. Läs felmeddelandet nedan:", Color.Red);
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                Console.WriteLine("\nKlicka enter för att gå tillbaka till huvudmenyn", Color.Pink);

                //show main Menu when user press enter
                ConsoleKeyInfo key = Console.ReadKey();
                Menus menu = new Menus();

                if (key.Key.Equals(ConsoleKey.Enter))
                {
                    Console.Clear();
                    menu.Mainmenu();
                }
            }
            Console.ReadLine();
        }

        //get token
        public string GetToken()
        {
            string clientId = "85b32c3f97a74efcade8f9768c89442d";
            string clientSecret = "49234c11effd4e71b8a6bdae1307fc4a";
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);

            HttpClient client = new HttpClient();

            //Define Headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(credentials)));

            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
            requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

            //Request Token
            var request = client.PostAsync("https://accounts.spotify.com/api/token", requestBody).Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var tokenResult = JsonConvert.DeserializeObject<AccessToken>(response);

            return tokenResult.access_token;
        }

        //show search result
        public void showSearchResult(string input, SearchResult searchResult)
        {
            Console.WriteLine("Du sökte efter: " + input, Color.DeepPink);
            Console.WriteLine("==================================\n", Color.DeepPink);

            int i = 0;

            foreach (Item items in searchResult.tracks.items)
            {
                string singer = "";
                foreach (Artist artist in items.artists)
                {
                    singer += artist.name + "  ";
                }
                Console.WriteLine($"Låtnamn: {items.name}");
                Console.WriteLine($"Artist: {singer}");
                Console.WriteLine("------------------------------------------------------------------------------------", Color.Pink);

                i++;
            }

            //show search menu
            Menus menu = new Menus();
            menu.SearchMenu();
        }
    }
}