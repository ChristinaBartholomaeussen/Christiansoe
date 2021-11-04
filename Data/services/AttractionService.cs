using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using christiansoe.Data.models;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;

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
            // Dokumentation: https://www.thecodebuzz.com/efcore-dbcontext-cannot-access-disposed-object-net-core/
            var attractions = await _applicationContext.Attractions.ToListAsync();
            return attractions;
        }


        public async Task<List<GeoCoordinate>> SortCoordinates(List<GeoCoordinate> geoCoordinates)
        {
            //Færgeterminalen - default det første element
            var attractions = await _applicationContext.Attractions.ToListAsync();
            var firstElement = attractions.First();
            var defaultLatitude = firstElement.Latitude;
            var defaultLongitude = firstElement.Longitude;
            var defaultCoordinates = new GeoCoordinate(defaultLatitude, defaultLongitude);

            //Originale liste 
            var original = geoCoordinates;
            
            //kopi af koordinator 
            var copy = new List<GeoCoordinate>();

            while (original.Count != 0)
            {
                var nearestCoord = original.Select(x =>
                        new GeoCoordinate(x.Latitude, x.Longitude))
                    .OrderBy(x => x.GetDistanceTo(defaultCoordinates))
                    .First();
                copy.Add(nearestCoord);

                defaultCoordinates = nearestCoord;

                original.Remove(nearestCoord);
                
            }

            return copy;

        }
    }
}