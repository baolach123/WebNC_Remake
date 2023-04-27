using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extentions;

namespace TatBlog.Services.Blogs
{
    //lớp định nghĩa các phương thức truy vấn từ interface IBlogRepository
    public class BlogRepository : IBlogRepository
    {
        //Cài đặt phương thức khởi tạo
        private readonly BlogDbContext dbContext;

        public BlogRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //Lấy list chuyên mục và số lượng bài viết
        public async Task<IList<CategoryItem>> GetCategoriesAsync(bool showOnMenu = false, CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = dbContext.Set<Category>();

            //Ktra showOnMenu=false hay khong 
            if(showOnMenu)
            {
                categories=categories.Where(i=>i.ShowOnMenu);
            }

            return await categories
                .OrderBy(i=>i.Name)
                .Select(i=> new CategoryItem()
                {
                    Id = i.Id,
                    Name = i.Name,
                    UrlSlug = i.UrlSlug,
                    Description = i.Description,
                    ShowOnMenu = i.ShowOnMenu,
                    PostCount = i.Posts.Count(p=>p.IsPublished)
                }).ToListAsync(cancellationToken);
        }

        public Task<IPagedList<TagItem>> GetPagedTagsAsync(IPagingParams pagingParams, CancellationToken cancellationToken = default)
        {
            var tagQuery = dbContext.Set<Tag>()
                .Select(i => new TagItem()
                {
                    Id =i.Id,
                    Name = i.Name,
                    UrlSlug = i.UrlSlug,
                    Description = i.Description,
                    PostCount = i.Posts.Count(p=> p.IsPublished)
                });

            return tagQuery.ToPagedListAsync(pagingParams,cancellationToken);
        }


        //Cài đặt phương thức 

        public async Task<Post> GetPostBySlugMonthYearAsync(int year, int month, string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Post> postsQuery = dbContext.Set<Post>()
                .Include(x => x.Category)
                .Include(x => x.Author);

            if (year > 0)
            {
                postsQuery=postsQuery.Where(x=>x.PostedDate.Year == year);
            }
            if (month > 0 &&  month <= 12)
            {
                postsQuery=postsQuery.Where(x=>x.PostedDate.Month == month);
            }
            
            if (!string.IsNullOrWhiteSpace(slug))
            {
                postsQuery=postsQuery.Where(x=>x.UrlSlug == slug);
            }

            return await postsQuery.FirstOrDefaultAsync(cancellationToken);

        }


        //Tim n bai post nhieu viewcount nhat
        public async Task<IList<Post>> GetPostsMostWatch(int viewNumber, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<Post>()
                .Include(p => p.Author)
                .Include(p => p.Category)
                .OrderByDescending(p => p.ViewCount)
                .Take(viewNumber)
                .ToListAsync(cancellationToken);
        }

        //Tăng viewcount
        public async Task IncreaseViewCountAsync(int postId, CancellationToken cancellationToken = default)
        {
            await dbContext.Set<Post>()
                .Where(p => p.Id == postId)
                .ExecuteUpdateAsync(p =>
                p.SetProperty(x => x.ViewCount, x => x.ViewCount + 1), cancellationToken);
        }

        //Ktra slug da co hay chua
        public async Task<bool> IsHasSlugInPost( int postId, string slug, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<Post>()
                .AnyAsync(p=>p.Id!= postId && p.UrlSlug==slug, cancellationToken);
        }
    }
}
