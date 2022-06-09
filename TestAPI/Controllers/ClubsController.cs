using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Repositories;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        public ClubsController(DataContext context)
        {
            _context = context;
        }

        private readonly DataContext _context;

        private IClubsRepository _clubsRepository;
        private IClubsRepository clubsRepository
        {
            get
            {
                if (_clubsRepository == null)
                {
                    _clubsRepository = new ClubsRepository(_context);
                }
                return _clubsRepository;
            }
        }

        [HttpGet("GetClubs")]
        public async Task<ActionResult<List<Club>>> Get()
        {
            return Ok(await clubsRepository.GetClubs());
        }

        [HttpGet("GetClub/{id}")]
        public async Task<ActionResult<Club>> Get(int id)
        {
            var club = await clubsRepository.GetClubAsync(id);

            return club != null ? Ok(club) : BadRequest($"No se encontró el club.({id})");
        }

        [HttpPost("AddClub")]
        public async Task<ActionResult<List<Club>>> AddClub(Club club)
        {
            clubsRepository.AddClub(club);
            return Ok(await clubsRepository.GetClubs());
        }

        [HttpPut("UpdateClub")]
        public async Task<ActionResult<List<Club>>> UpdateClub(Club request)
        {
            clubsRepository.UpdateClub(request);

            return Ok(await clubsRepository.GetClubs());
        }

        [HttpDelete("RemoveClub/{id}")]
        public async Task<ActionResult<List<Club>>> RemoveClub(int id)
        {
            var club = _context.Clubs.FirstOrDefault(x => x.Id == id);

            if (club == null)
            {
                return BadRequest("No se encontró el club.");
            }

            clubsRepository.RemoveClub(club);

            return Ok(await clubsRepository.GetClubs());
        }
    }
}
