using System.Collections.Generic;

namespace christiansoe.Data.models
{
    public class Route
    {
        //vi bruges readonly, fordi vi kun skal kunne læse den
        public readonly List<Attraction> Attractions = new();
        public string Duration { get; set; }

    }
}