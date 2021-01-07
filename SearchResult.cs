using System;
using System.Collections.Generic;
using System.Text;

namespace DT071G_project
{
    //classes to hold search data
    class SearchResult
    {
        public Track tracks { get; set; }
    }

    class Track
    {        
        public List<Item> items { get; set; }
    }

    class Item
    {
        public string name { get; set; }
        public List<Artist> artists { get; set; }

    }

    class Artist
    {
        public string name { get; set; }
    }
}