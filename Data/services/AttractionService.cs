using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise.Extensions;
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

        public async Task<List<Attraction>> GetAttractions()
        {
            // Dokumentation: https://www.thecodebuzz.com/efcore-dbcontext-cannot-access-disposed-object-net-core/
            var attractions = await _applicationContext.Attractions.ToListAsync();
            return attractions;
        }


        public async Task<List<GeoCoordinate>> SortCoordinates(List<Attraction> attractionsInRoute)
        {
            //Færgeterminalen - default det første element
            List<Attraction> allAttractions = await _applicationContext.Attractions.ToListAsync();
            Attraction firstElement = allAttractions.First();
            double startLatitude = firstElement.Latitude;
            double startLongitude = firstElement.Longitude;
            
            GeoCoordinate startCoordinates = new GeoCoordinate(startLatitude, startLongitude);
            
            List<GeoCoordinate> geoCoordinates = new List<GeoCoordinate>();

            while (!attractionsInRoute.IsNullOrEmpty())
            {
                var closestAttraction = attractionsInRoute.Select(a =>
                        new GeoCoordinate(a.Latitude, a.Longitude))
                    .OrderBy(a => a.GetDistanceTo(startCoordinates))
                    .First();
                geoCoordinates.Add(closestAttraction);

                startCoordinates = closestAttraction;

                attractionsInRoute.Remove(attractionsInRoute.Single(a => 
                    a.Latitude == closestAttraction.Latitude  && a.Longitude == closestAttraction.Longitude));
                
            }

            return geoCoordinates;

        }
    }
}