using Autofac;
using ELM.Organization.BusinessObjects;
using ELM.Organization.Services;

namespace ELM.Models;

public class MemberModel
{
    private IOrgMemberServices _memberServices;
    private ILifetimeScope _scope;

    public MemberModel()
    {
        
    }

    public MemberModel(IOrgMemberServices memberServices, ILifetimeScope scope)
    {
        _memberServices = memberServices;
        _scope = scope;
    }
    
    public void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _memberServices = _scope.Resolve<IOrgMemberServices>();
    }
    
    public int MemberId { get; set; }
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Image { get; set; }
    public int OrgId { get; set; }
    public string? Role { get; set; }
    public string? Status { get; set; }
    public List<Member> Members { get; set; }


    public void GetMemberByOrg(int id)
    {
        
        Members  =  _memberServices.GetMemberByOrg(id);

    }
}