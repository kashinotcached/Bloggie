using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class AddModel : PageModel
{
    private readonly IBlogPostRepository blogPostRepository;

    [BindProperty]
    public AddBlogPost AddBlogPostRequest { get; set; }

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
            UrlHandle = AddBlogPostRequest.UrlHandle
        };

        await blogPostRepository.AddAsync(blogPost);

        return RedirectToPage("List");
    }
}
