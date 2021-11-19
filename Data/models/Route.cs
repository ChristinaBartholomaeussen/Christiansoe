using System.Collections.Generic;

namespace christiansoe.Data.models
{
    public class Route
    {
        public List<Attraction> Attractions = new List<Attraction>();
        public string Duration { get; set; }

    }
}