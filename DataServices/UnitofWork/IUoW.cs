using DataServices.Repositories;

namespace DataServices.UnitofWork
{
    public interface IUoW
    {
        IGetTitlesRepo GetTitlesRepo { get; }
        ISubmitOrderRepo SubmitOrderRepo { get; }
        IGetReceiptRepo GetReceiptRepo { get; }

        
    }
}

