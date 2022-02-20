using ELM.Users.BusinessObjects;

namespace ELM.Users.Services;

public interface IMemberService
{
     Task CreateUser(UserRegister userRegister);
}