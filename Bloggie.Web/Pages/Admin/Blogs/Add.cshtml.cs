using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class AddModel : PageModel
{
    private readonly IBlogPostRepository blogPostRepository;

    [BindProperty]
    public AddBlogPost AddBlogPostRequest { get; set; }

    [BindProperty]
    public IFormFile FeaturedImage { get; set; }

    [BindProperty]
    public string Tags { get; set; }

    public AddModel(IBlogPostRepository blogPostRepository)
    {
        this.blogPostRepository = blogPostRepository;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var blogPost = new BlogPost()
        {
            Heading = AddBlogPostRequest.Heading,
            Author = AddBlogPostRequest.Author,
            Content = AddBlogPostRequest.Content,
            FeatureImageUrl = AddBlogPostRequest.FeatureImageUrl,
            Id = AddBlogPostRequest.Id,
            PageTitle = AddBlogPostRequest.PageTitle,
            PublishedDate = AddBlogPostRequest.PublishedDate,
            ShortDescription = AddBlogPostRequest.ShortDescription,
            UrlHandle = AddBlogPostRequest.UrlHandle,
            Visible = AddBlogPostRequest.Visible,
            Tags = new List<Tag>(Tags.Split(',').Select(x=> new Tag() { Name = x.Trim() }))
        };

        await blogPostRepository.AddAsync(blogPost);

        var notification = new Notification
        {
            Message = "New blog created!",
            Type = Enums.NotificationType.Success
        };

        TempData["Notification"] = JsonSerializer.Serialize(notification);

        return RedirectToPage("List");
    }
}
