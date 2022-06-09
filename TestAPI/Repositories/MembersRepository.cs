using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly DataContext data;

        public MembersRepository(DataContext data)
        {
            this.data = data;
        }
        public Member GetMember(long id)
        {
            return data.Members.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Member> GetMemberAsync(long id)
        {
            return await data.Members.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Member>> GetMembers()
        {
            return await data.Members.ToListAsync();
        }

        public void AddMember(Member member)
        {
            data.Members.Add(member);
            data.SaveChanges();
        }

        public Member UpdateMember(Member memberRequest)
        {
            var member = data.Members.FirstOrDefault(x => x.Id == memberRequest.Id);

            if (member != null)
            { 
                data.Members.Update(member);
                data.SaveChanges();
            }

            return member;
        }

        public void RemoveMember(Member member)
        {
            data.Members.Remove(member);
        }
    }
}
