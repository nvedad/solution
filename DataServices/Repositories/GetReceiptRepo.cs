using DataServices.DBModels;

namespace DataServices.Repositories
{
    public class GetReceiptRepo : IGetReceiptRepo
    {
        private readonly PubsContext _context;
        public GetReceiptRepo(PubsContext context)
        {
            _context = context;
        }

        List<Sale> IGetReceiptRepo.GetReceipt(string id)
        {
            return (from d in _context.Sales
                    where id == d.OrdNum
                    select d).ToList();
        }
    }
}
