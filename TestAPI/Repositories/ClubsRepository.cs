using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class ClubsRepository : IClubsRepository
    {
        private readonly DataContext data;

        public ClubsRepository(DataContext data)
        {
            this.data = data;
        }

        public Club GetClub(long id)
        {
            return data.Clubs.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Club> GetClubAsync(long id)
        {
            return await data.Clubs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Club>> GetClubs()
        {
            return await data.Clubs.ToListAsync();
        }

        public void AddClub(Club club)
        {
            data.Clubs.Add(club);
            data.SaveChanges();
        }

        public Club UpdateClub(Club clubRequest)
        {
            var club = data.Clubs.FirstOrDefault(x => x.Id == clubRequest.Id);

            if (club != null)
            {
                data.Clubs.Update(club);
                data.SaveChanges();
            }

            return club;
        }

        public void RemoveClub(Club club)
        {
            data.Clubs.Remove(club);
        }

    }
}
