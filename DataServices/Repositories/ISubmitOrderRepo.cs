using DataServices.DBModels;
using DataServices.Model;

namespace DataServices.Repositories
{
    public interface ISubmitOrderRepo
    {
        public void SubmitOrder(string title, int qty);
        
    }
}


