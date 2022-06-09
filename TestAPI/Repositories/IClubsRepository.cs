using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IClubsRepository
    {
        Club GetClub(long id);
        Task<Club> GetClubAsync(long id);
        Task<List<Club>> GetClubs();
        void AddClub(Club Club);
        Club UpdateClub(Club Club);
        void RemoveClub(Club Club);
    }
}
