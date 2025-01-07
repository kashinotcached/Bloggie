using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users;

public class IndexModel : PageModel
{
    private readonly IUserRepository userRepository;

    public List<User> Users { get; set; }

    public IndexModel(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public async Task<IActionResult> OnGet()
    {
        var users = await userRepository.GetAll();
        
        Users= new List<User>();
        foreach (var user in users)
        {
            Users.Add(new User()
            {
                Id = Guid.Parse(user.Id),
                Email = user.Email,
                Username = user.UserName
            });
        }

        return Page();
    }
}
