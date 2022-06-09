using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IMembersRepository
    {
        Member GetMember(long id);
        Task<Member> GetMemberAsync(long id);
        Task<List<Member>> GetMembers();
        void AddMember(Member member);
        Member UpdateMember(Member member);
        void RemoveMember(Member member);
    }
}
