using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class AddModel : PageModel
{
    private readonly BloggieDbContext bloggieDbContext;

    [BindProperty]
    public AddBlogPost AddBlogPostRequest { get; set; }

    public AddModel(BloggieDbContext bloggieDbContext) => this.bloggieDbContext = bloggieDbContext;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
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

        bloggieDbContext.BlogPosts.Add(blogPost);
        bloggieDbContext.SaveChanges();

        return RedirectToPage("List");
    }
}
