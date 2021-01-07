using System;
using System.Drawing;
using Console = Colorful.Console;

namespace DT071G_project
{
    class Menus
    {
        //main menu 
        public void Mainmenu()
        {

            //create instance of classes
            FavoriteMusicRepository favoriteMusicRepository = new FavoriteMusicRepository();
            Api api = new Api();

            // Display title
            Console.WriteLine("MIN MUSIKSIDA\r", Color.DeepPink);
            Console.WriteLine("====================================================\n", Color.Pink);

            // Show options
            Console.WriteLine("MIN MUSIKMENY:\n", Color.Pink);
            Console.WriteLine("1: Se dina favoritlåtar\n");
            Console.WriteLine("2: Sök på en artist på spotify för att hitta favoritlåt\n");
            Console.WriteLine("3: Sök på en låtnamn på spotify för att hitta favoritlåt\n");
            Console.WriteLine("X: Stäng ner konsollapplikationen\n", Color.Red);

            //Ask user to choose an option and read input
            Console.Write("\nVilket alternativ har du valt? Skriv i numret och klicka ENTER \n", Color.Pink);
            string option = Console.ReadLine().ToLower();

            //switch, choose case based on input
            switch (option)
            {
                case "1":
                    MusicMenu();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Sök på artistens namn:", Color.DeepPink);

                    string artist = Console.ReadLine().ToLower();
                    //replace space with +
                    
                    api.GetData(artist.Replace(' ', '+'));

                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Sök på låttitel:", Color.DeepPink);

                    string title = Console.ReadLine().ToLower();
                    //replace space with +

                    api.GetData(title.Replace(' ', '+'));
                    break;
                case "x":
                    Console.Clear();
                    Console.WriteLine("Tack för idag, hoppas vi ses snart igen \n");
                    //close console
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ojdå. Nu valde du inget av alternativen. Testa igen. \n", Color.Red);
                    Mainmenu();
                    break;
            }
        }

        //favorite music menu
        public void MusicMenu()
        {
            //create instance of classes
            FavoriteMusicRepository favoriteMusicRepository = new FavoriteMusicRepository();

            //show favorite music list
            favoriteMusicRepository.showMusic();

            //Display title
            Console.WriteLine("MusikMeny:", Color.DeepPink);
            Console.WriteLine("==========================\n", Color.DeepPink);

            //show options
            Console.WriteLine("1: Lägg till en till favoritlåt");
            Console.WriteLine("2: Ta bort favoritlåt ");
            Console.WriteLine("3: Gå tillbaka till huvudmenyn ");

            //Ask user to choose an option and read input
            Console.Write("\nVilket alternativ har du valt? Skriv i siffran och klicka enter \n", Color.Pink);
            string musicOption = Console.ReadLine().ToLower();

            //switch, choose case based on input
            switch (musicOption)
            {
                case "1":

                    string artist = "";
                    string songName = "";

                    //clear console, show text and read input
                    Console.Clear();
                    Console.WriteLine("Lägg till favoritlåt i listan:\n");
                    Console.Write("Artistens namn: ");
                    artist = Console.ReadLine();            
                    Console.Write("Låtnamn: ");
                    songName = Console.ReadLine();

                    //do while artist or songName is empty
                    while (string.IsNullOrEmpty(songName) || string.IsNullOrEmpty(artist))
                    {
                        Console.Clear();
                        Console.WriteLine("Obs! Du glömde skriva in artist eller låtnamn.\n", Color.DarkRed);
                        Console.WriteLine("Gör ett nytt försök\n", Color.DeepPink);

                        Console.Write("Artistens namn: ");
                        artist = Console.ReadLine();
                        Console.Write("Låtnamn: ");
                        songName = Console.ReadLine();
                    }

                    //add object 
                    FavoriteMusic favoriteMusic = new FavoriteMusic();
                    favoriteMusic.Artist = artist;
                    favoriteMusic.SongName = songName;

                    //send object to function AddPost
                    favoriteMusicRepository.AddFavoriteMusic(favoriteMusic);

                    //call on message function
                    Messages("sucessfullAdd");
                    break;

                case "2":
                    //clear console
                    Console.Clear();

                    //show favorite music
                    favoriteMusicRepository.showMusic();

                    //ask user for index on favorite song to delete and read input
                    Console.Write("Ange index på favoritlåten du vill radera: ", Color.Pink);
                    string indexInput = Console.ReadLine();
                    int index;

                    //check if input is a number
                    bool isNumber = int.TryParse(indexInput, out index);

                    //do while index isn´t a number
                    while (isNumber == false)
                    {
                        Console.Clear();
                        //show favorite songs
                        favoriteMusicRepository.showMusic();

                        //ask user for index on favorite song to delete and read input
                        Console.WriteLine("Ops! Nu skrev du inte en siffra, testa igen\n", Color.DarkRed);
                        Console.Write("Ange index på favoritlåten du vill radera:\n ", Color.Pink);
                        indexInput = Console.ReadLine();
                        isNumber = int.TryParse(indexInput, out index);
                    }

                    //send index to function "DeleteFavoriteMusic"
                    bool result = favoriteMusicRepository.DeleteFavoriteMusic(Convert.ToInt32(index));

                    //send different messages if result is true or false
                    if (result == false) {
                        Messages("noIndexToDelete");
                    }   else
                    {
                        Messages("sucessfullDelete");
                    }
                    break;
                case "3":
                    Console.Clear();
                    Mainmenu();
                    break;

                default:
                    Messages("MusicMenuOptionError");
                    break;
            }
        }

        //function to handle messages
        public void Messages(string message)
        {
            //clear console
            Console.Clear();

            //switch- show different messages
            switch (message)
            {
                case "sucessfullAdd":
                    Console.WriteLine("\nDu lyckades lägga till en låt, klicka ENTER för att gå tillbaka till MusikMeny", Color.Green);
                    break;
                case "sucessfullDelete":
                    Console.WriteLine("\nDu lyckades radera vald låt, klicka ENTER för att gå tillbaka till MusikMeny", Color.Green);
                    break;
                case "noNumberDelete":
                    Console.WriteLine("\nDu lyckades inte skriva en siffra, klicka ENTER för att gå tillbaka till MusikMeny och försök igen", Color.DarkRed);
                    break;
                case "noIndexToDelete":
                    Console.WriteLine("\nDu lyckades inte radera eftersom indexet du angav inte fanns. Klicka ENTER för att gå tillbaka till MusikMeny och försök igen", Color.DarkRed);
                    break;
                case "MusicMenuOptionError":
                    Console.WriteLine("\nOjdå. Nu valde du inget av alternativen. Klicka ENTER för att gå tillbaka till MusikMenyn och försök igen", Color.DarkRed);
                    break;
            }

            //show MusicMenu when user press enter
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key.Equals(ConsoleKey.Enter))
            {
                MusicMenu();
            }
        }
    }
}
