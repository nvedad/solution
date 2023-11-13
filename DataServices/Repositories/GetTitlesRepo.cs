using DataServices.DBModels;
using System.Linq;

namespace DataServices.Repositories
{
    public class GetTitlesRepo : IGetTitlesRepo
    {
        private readonly PubsContext _context;
        public GetTitlesRepo(PubsContext context)
        {
            _context = context;
        }



        public List<Title> GetTitles()
        {
            // return _context.Titles.ToList();
            return _context.Titles.ToList();

        }
    }
}

