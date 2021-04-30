namespace CeroFilas.Web.ViewModels.BlogPosts
{
    using CeroFilas.Web.ViewModels.Common.Pagination;

    public class BlogPostsPaginatedListViewModel
    {
        public PaginatedList<BlogPostViewModel> BlogPosts { get; set; }
    }
}
