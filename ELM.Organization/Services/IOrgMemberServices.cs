using ELM.Organization.BusinessObjects;

namespace ELM.Organization.Services;

public interface IOrgMemberServices
{
    void AddMember(Member member);
    void AddMemberList(List<Member> memberList);
}