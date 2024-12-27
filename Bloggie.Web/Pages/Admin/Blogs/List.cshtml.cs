using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs;

[Authorize(Roles = "Admin")]
public class ListModel : PageModel
{
    private readonly IBlogPostRepository blogPostRepository;

    public List<BlogPost> BlogPosts { get; set; }

    public ListModel(IBlogPostRepository blogPostRepository)
    {
        this.blogPostRepository = blogPostRepository;
    }

    public async Task OnGet()
    {
        var notificationJson = TempData["Notification"]?.ToString();
        if(notificationJson != null)
            ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);

        BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
    }
}
