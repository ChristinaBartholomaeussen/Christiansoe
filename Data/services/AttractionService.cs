using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using christiansoe.Data.models;
using GeoCoordinatePortable;


namespace christiansoe.Data.services
{
    public class AttractionService : IAttractionService
    {

        private readonly ApplicationContext _applicationContext;

        public AttractionService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Attraction>> GetAttraction()
        {
            await using var context = _applicationContext;
            return context.Attractions.ToList();
        }
        


        public void SortAttractions(List<Attraction> attractions)
        {
            //Ny liste med alle koordinater
            List<GeoCoordinate> geoCoordinates = new List<GeoCoordinate>();

            //Adder attrationers lat + lon til geoListen
            foreach (Attraction a in attractions)
            {
                geoCoordinates.Add(new GeoCoordinate(a.Latitude, a.Longitude));
            }

            var distancenBetween = geoCoordinates.Zip(geoCoordinates.Skip(1), 
                (first, sec) => first.GetDistanceTo(sec));
            
            
            foreach (var d in distancenBetween)
            {
                Console.WriteLine(d);
            }

            
        }
        

    }
}