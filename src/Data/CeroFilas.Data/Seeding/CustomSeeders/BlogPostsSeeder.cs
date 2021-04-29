namespace CeroFilas.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CeroFilas.Common;
    using CeroFilas.Data.Models;

    public class BlogPostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BlogPosts.Any())
            {
                return;
            }

            var blogPosts = new BlogPost[]
                {
                    new BlogPost // Id = 1
                    {
                        Title = "Lorem Ipsum Dolor Sit Ement",
                        Content = @"Quisquam vel ut sint cum eos hic dolores aperiam. Sed deserunt et. Inventore et et dolor consequatur itaque ut voluptate sed et. Magnam nam ipsum tenetur suscipit voluptatum nam et est corrupti.",
                        Author = "Elizabeth Scarcella",
                        ImageUrl = GlobalConstants.Images.StressedSkin,
                    },
                    new BlogPost // Id = 2
                    {
                        Title = "Inventore et et dolor consequatur",
                        Content = @"Quisquam vel ut sint cum eos hic dolores aperiam. Sed deserunt et. Inventore et et dolor consequatur itaque ut voluptate sed et. Magnam nam ipsum tenetur suscipit voluptatum nam et est corrupti.",
                        Author = "Michele McDonough",
                        ImageUrl = GlobalConstants.Images.SummerBeautyTips,
                    },
                    new BlogPost // Id = 3
                    {
                        Title = "Sed deserunt et?",
                        Content = @"Quisquam vel ut sint cum eos hic dolores aperiam. Sed deserunt et. Inventore et et dolor consequatur itaque ut voluptate sed et. Magnam nam ipsum tenetur suscipit voluptatum nam et est corrupti.",
                        Author = "Michele McDonough",
                        ImageUrl = GlobalConstants.Images.MakeUp,
                    },
                    new BlogPost // Id = 4
                    {
                        Title = "Essentials for Healthy ",
                        Content = @"Quisquam vel ut sint cum eos hic dolores aperiam. Sed deserunt et. Inventore et et dolor consequatur itaque ut voluptate sed et. Magnam nam ipsum tenetur suscipit voluptatum nam et est corrupti.",
                        Author = "Elizabeth Scarcella",
                        ImageUrl = GlobalConstants.Images.SummerHealthyHair,
                    },
                };

            // Need them in particular order
            foreach (var blogPost in blogPosts)
            {
                await dbContext.AddAsync(blogPost);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
