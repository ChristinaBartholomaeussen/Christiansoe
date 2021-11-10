using System.Collections.Generic;
using System.Threading.Tasks;
using christiansoe.Data.models;
using GeoCoordinatePortable;

namespace christiansoe.Data.services
{
    public interface IAttractionService
    {
        public Task<List<Attraction>> GetAttraction();

        public Task<List<GeoCoordinate>> SortCoordinates(List<Attraction> attractions);
    }
}