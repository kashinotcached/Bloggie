using Microsoft.AspNetCore.Identity;

namespace Bloggie.Web.Repositories;

public interface IUserRepository
{
    Task<bool> Add(IdentityUser identityUser, string password, List<string> roles);

    Task<IEnumerable<IdentityUser>> GetAll();
}
