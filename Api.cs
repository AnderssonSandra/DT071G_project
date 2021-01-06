using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DT071G_project
{
    class Api
    {
        //Class to get songs from artist
        public void GetDataByArtist(string input)
        {
            string url = "https://api.spotify.com/v1/search?q=" + input + "&type=artist";
            Console.WriteLine(url);
            /*HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.spotify.com/v1/search?q=" + input + "&type=artist");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "BQBTRjRWMIGCvHXcFgSOo091dIJ18-TSKlcpDbQzsz36aIIoI20zpBrx-18RQ6tD9Ojdl51V0Wwx3pVybtwxBf9_sSctm7k2ldUg1_hf4GVa9JMY8ONCrcixuJ4l1GoqY7dy87l24-bNxP_3ulvhWfqmQRS9IGU-zmRT9vmIPIGJJ2unPSj9L2sQqFSVxTpcopr5zqaIfIopoCJyHd6IqqE_fcyssLUGzCnXee_m4zDKxd4a0QkC0fJAP7-7kFXj86fTXYwNE1ZjREj4uZrCwNHD0UljiSIFmqY");
            HttpResponseMessage response = client.GetAsync("api/Values").Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
                Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.ReadLine();*/

            /*
             result= json data

            Serialize data function (jsonData)
            change from json data to list, send to show data 

            show data(list)
            show searchresult list 
            klicka enter för att gå tillbaka till huvudmenyn 

             */

        }

        //Class to get songs from song name
        public void GetDataByTitle(string input)
        {
            string url = "https://api.spotify.com/v1/search?q=" + input + "&type=track";
            Console.WriteLine(url);
        }

        //funktion som connectar till api och hämtar json format för artist: getDataByArtist

        //funktion som connectar till api och hämtar json format för songnamn:getDataBySongname

        //funktion som konverterar data till C# object : serialize 

        //funktion som visar data: showSearchResult 


    }
}
