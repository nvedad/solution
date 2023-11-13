using DataServices.DBModels;
using DataServices.Repositories;

namespace DataServices.UnitofWork
{
    public class UoW : IUoW
    {
        private readonly PubsContext _context;
        public UoW(PubsContext context)
        {
            _context = context;
        }
        public IGetTitlesRepo GetTitlesRepo
        {
            get
            {
                return new GetTitlesRepo(_context);
            }

        }
        public ISubmitOrderRepo SubmitOrderRepo
        {
            get
            {
                return new SubmitOrderRepo(_context);
            }
        }

        public IGetReceiptRepo GetReceiptRepo
        {
            get
            {
                return new GetReceiptRepo(_context);
            }
        }
    }
}