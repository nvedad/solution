using DataServices.DBModels;

namespace DataServices.Repositories
{
    public interface IGetReceiptRepo
    {
        List<Sale> GetReceipt(string Id);
    }
}
