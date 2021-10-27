using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using christiansoe.Data.models;

namespace christiansoe.Data.services
{
    public interface IAttractionService
    {
        public Task<List<Attraction>> GetAttraction();

        public void SortAttractions(List<Attraction> attractions);


    }
    
}