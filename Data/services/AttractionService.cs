using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using christiansoe.Data.models;



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

    }
}