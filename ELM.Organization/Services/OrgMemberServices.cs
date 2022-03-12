using ELM.Organization.BusinessObjects;
using ELM.Organization.Entities;
using ELM.Organization.UnitOfWorks;

namespace ELM.Organization.Services;

public class OrgMemberServices : IOrgMemberServices
{
    private readonly IOrgMemberUnitOfWork _orgMemberUnitOfWork;

    public OrgMemberServices(IOrgMemberUnitOfWork orgMemberUnitOfWork)
    {
        _orgMemberUnitOfWork = orgMemberUnitOfWork;
    }
    
    
    public void AddMember(Member member)
    {
        var MemberData = new OrgMembers()
        {
           Id = member.Id,
           OrgId = member.OrgId,
           UserId = member.UserId,
           Role = member.Role,
           Status = member.Status,
           IsActive = member.IsActive,
           Date = member.Date
               
           
        };
        
        _orgMemberUnitOfWork.OrgMember.Add(MemberData);
        _orgMemberUnitOfWork.Save();
    }
    public void AddMemberList(List<Member> memberList)
    { 
        var memberData = new List<OrgMembers>();
        foreach (var member in memberList)
        {
         memberData.Add(new OrgMembers()
         {  
                        Id = member.Id,
                         OrgId = member.OrgId,
                         UserId = member.UserId,
                         Role = member.Role,
                         Status = member.Status,
                         IsActive = member.IsActive,
                         Date = member.Date
         });
            
        }

        foreach (var data in memberData)
        {
            _orgMemberUnitOfWork.OrgMember.Add(data); 
        } 
        
        _orgMemberUnitOfWork.Save();
    }

    public List<Member> GetMemberByOrg(int orgId)
    {
        var orgMember = _orgMemberUnitOfWork.OrgMember.GetByOrgId(orgId);
        var members = new List<Member>();
        foreach (var item in orgMember)
        {
             members.Add(new Member()
                    {
                        Id = item.Id,
                        OrgId = item.OrgId,
                        UserId = item.UserId,
                        Role = item.Role,
                        Status = item.Status,
                        IsActive = item.IsActive,
                        Date = item.Date


                    });
        }
        
       

        return members;
    }
    
    
}

 