using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Repositories;

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

        private readonly DataContext _context;

        private IMembersRepository _membersRepository;
        private IMembersRepository membersRepository
        {
            get
            {
                if (_membersRepository == null)
                {
                    _membersRepository = new MembersRepository(_context);
                }
                return _membersRepository;
            }
        }

        [HttpGet("GetMembers")]
        public async Task<ActionResult<List<Member>>> Get()
        {
            return Ok(await membersRepository.GetMembers());
        }

        [HttpGet("GetMember/{id}")]
        public async Task<ActionResult<Member>> Get(int id)
        {
            var member = await membersRepository.GetMemberAsync(id);
            
            return member != null ? Ok(member) : BadRequest($"No se encontró el socio para el nro indicado.({id})");
        }

        [HttpPost("AddMember")]
        public async Task<ActionResult<List<Member>>> AddMember(Member member)
        {
            membersRepository.AddMember(member);
            return Ok(await membersRepository.GetMembers());
        }

        [HttpPut("UpdateMember")]
        public async Task<ActionResult<List<Member>>> UpdateMember(Member request)
        {
            membersRepository.UpdateMember(request);

            return Ok(await membersRepository.GetMembers());
        }

        [HttpDelete("RemoveMember/{id}")]
        public async Task<ActionResult<List<Member>>> RemoveMember(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                return BadRequest("No se encontró el socio.");
            }

            membersRepository.RemoveMember(member);

            return Ok(await membersRepository.GetMembers());
        }
    }
}
