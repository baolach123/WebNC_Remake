using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

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
