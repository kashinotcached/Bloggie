using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class EditModel : PageModel
{
    private readonly BloggieDbContext bloggieDbContext;

    [BindProperty]
    public BlogPost blogPost { get; set; }

    public EditModel(BloggieDbContext bloggieDbContext)
    {
        this.bloggieDbContext = bloggieDbContext;
    }

    public void OnGet(Guid id)
    {
        blogPost = bloggieDbContext.BlogPosts.Find(id);
    }

    public IActionResult OnPost()
    {
        var existingBlogPost = bloggieDbContext.BlogPosts
            .Find(blogPost.Id);

        if(existingBlogPost != null)
        {
            existingBlogPost.Heading = blogPost.Heading;
            existingBlogPost.PageTitle = blogPost.PageTitle;
            existingBlogPost.Content = blogPost.Content;
            existingBlogPost.ShortDescription = blogPost.ShortDescription;
            existingBlogPost.Author = blogPost.Author;
            existingBlogPost.FeatureImageUrl = blogPost.FeatureImageUrl;
            existingBlogPost.UrlHandle = blogPost.UrlHandle;
            existingBlogPost.PublishedDate = blogPost.PublishedDate;
            existingBlogPost.Author = blogPost.Author;
            existingBlogPost.Visible = blogPost.Visible;
        }

        bloggieDbContext.SaveChanges();
        return RedirectToPage("List");
    }
}
