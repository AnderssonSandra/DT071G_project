﻿using Newtonsoft.Json;
using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing;
using Console = Colorful.Console;
using System.Threading.Tasks;


namespace DT071G_project
{
    class Program
    {
        static void Main(string[] args)
        {
            //create instace of Menus class and call on MainMenu
            Menus menus = new Menus();

            menus.Mainmenu();

        }

    }

}