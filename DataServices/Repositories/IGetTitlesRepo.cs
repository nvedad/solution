using DataServices.DBModels;


namespace DataServices.Repositories
{
    public interface IGetTitlesRepo
    {
        List<Title> GetTitles();
    }
}
