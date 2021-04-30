namespace CeroFilas.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using CeroFilas.Services.Data.BlogPosts;
    using CeroFilas.Web.ViewModels.BlogPosts;
    using Microsoft.AspNetCore.Mvc;

    public class LatestBlogPostsViewComponent : ViewComponent
    {
        private readonly IBlogPostsService blogPostsService;

        public LatestBlogPostsViewComponent(IBlogPostsService blogPostsService)
        {
            this.blogPostsService = blogPostsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? count)
        {
            var viewModel = new BlogPostsListViewModel
            {
                BlogPosts = await this.blogPostsService.GetAllAsync<BlogPostViewModel>(count),
            };

            return this.View(viewModel);
        }
    }
}
