using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IBlogPostRepository blogPostRepository;

    [BindProperty]
    public EditBlogPostRequest BlogPost { get; set; }

    [BindProperty]
    public IFormFile FeaturedImage { get; set; }

    [BindProperty]
    public string Tags { get; set; }

    public EditModel(IBlogPostRepository blogPostRepository)
    {
        this.blogPostRepository = blogPostRepository;
    }

    public async Task OnGet(Guid id)
    {
        var blogPostDomainModel = await blogPostRepository.GetAsync(id);

        if (blogPostDomainModel != null && blogPostDomainModel.Tags != null)
        {
            BlogPost = new EditBlogPostRequest
            {
                Id = blogPostDomainModel.Id,
                Heading = blogPostDomainModel.Heading,
                PageTitle = blogPostDomainModel.PageTitle,
                Content = blogPostDomainModel.Content,
                ShortDescription = blogPostDomainModel.ShortDescription,
                FeatureImageUrl = blogPostDomainModel.FeatureImageUrl,
                UrlHandle = blogPostDomainModel.UrlHandle,
                PublishedDate = blogPostDomainModel.PublishedDate,
                Author = blogPostDomainModel.Author,
            };

            Tags = string.Join(",", blogPostDomainModel.Tags.Select(x => x.Name));
        }
    }

    public async Task<IActionResult> OnPostEdit()
    {
        try
        {
            var blogPostDomainModel = new BlogPost
            {
                Id = BlogPost.Id,
                Heading = BlogPost.Heading,
                PageTitle = BlogPost.PageTitle,
                Content = BlogPost.Content,
                ShortDescription = BlogPost.ShortDescription,
                FeatureImageUrl = BlogPost.FeatureImageUrl,
                UrlHandle = BlogPost.UrlHandle,
                PublishedDate = BlogPost.PublishedDate,
                Author = BlogPost.Author,
                Visible = BlogPost.Visible,
                Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
            };

            await blogPostRepository.UpdateAsync(blogPostDomainModel);

            ViewData["Notification"] = new Notification
            {
                Message = "Record Updated Successfully!",
                Type = Enums.NotificationType.Success
            };
        }
        catch (Exception ex)
        {
            ViewData["Notification"] = new Notification
            {
                Message = ex.Message,
                Type = Enums.NotificationType.Error
            };
        }

        return Page();
    }

    public async Task<IActionResult> OnPostDelete()
    {
        var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);

        if (deleted)
        {
            var notification = new Notification
            {
                Message = "Blog was deleted successfully!",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);
            return RedirectToPage("List");
        }

        return Page();
    }
}
