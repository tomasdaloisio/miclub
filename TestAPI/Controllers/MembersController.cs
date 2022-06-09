using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        public MembersController(DataContext context)
        {
            _context = context;
        }

        private static List<Member> members = new List<Member> { 
            new Member { 
                Id = 1,
                Name = "Tomas",
                LastName = "D'Aloisio",
                BirthDate = new DateTime(1999, 03, 11)
            },
            new Member {
                Id = 2,
                Name = "Rocio",
                LastName = "Albé",
                BirthDate = new DateTime(2000, 06, 22)
            }
        };
        private readonly DataContext _context;

        [HttpGet("GetMembers")]
        public async Task<ActionResult<List<Member>>> Get()
        {
            return Ok(await _context.Members.ToListAsync());
        }

        [HttpGet("GetMember/{id}")]
        public async Task<ActionResult<Member>> Get(int id)
        {
            var member = members.FirstOrDefault(x => x.Id == id);
            
            return member != null ? Ok(member) : BadRequest("No se encontró el socio para el nro indicado.");
        }

        [HttpPost("AddMember")]
        public async Task<ActionResult<List<Member>>> AddMember(Member member)
        {
            members.Add(member);
            return Ok(members);        
        }

        [HttpPut("UpdateMember")]
        public async Task<ActionResult<List<Member>>> UpdateMember(Member request)
        {
            var member = members.FirstOrDefault(x => x.Id == request.Id);

            if (member == null)
            {
                BadRequest("No se encontró el socio.");
            }

            member.Update(request);

            return Ok(members);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Member>>> UpdateMember(int id)
        {
            var member = members.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                BadRequest("No se encontró el socio.");
            }

            members.Remove(member);

            return Ok(members);
        }


    }
}
