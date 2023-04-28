using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{ 
    //Interface cho class truy vấn dữ liệu
    public interface IBlogRepository
    {
        //Tìm bài viết theo slug, tháng, năm (đăng bài)
        Task<Post> GetPostBySlugMonthYearAsync(// Nhớ thêm Async vì là hàm bất đồng bộ
            int year, int month, string slug, CancellationToken cancellationToken = default);

        //Lấy n post có nhiều lượt xem nhất
        Task<IList<Post>> GetPostsMostWatch(// Nhớ thêm Async vì là hàm bất đồng bộ
            int viewNumber, CancellationToken cancellationToken = default);

        //ktra post đã có slug hay chưa
        // Nhớ thêm Async vì là hàm bất đồng bộ
        Task<bool> IsHasSlugInPost(int postId, string slug, CancellationToken cancellationToken = default);


        //Tăng số lượt xem của post
        //Hàm này sẽ không trả về gì cả
        Task IncreaseViewCountAsync(int  postId, CancellationToken cancellationToken = default);


        //Lấy list category và đếm số bài viết trong category
        Task<IList<CategoryItem>> GetCategoriesAsync(bool showOnMenu=false
            ,CancellationToken cancellationToken = default);
        
        //Lay list the va phan trang theo pagaingParams
        Task<IPagedList<TagItem>> GetPagedTagsAsync(
            IPagingParams pagingParams, CancellationToken cancellationToken = default);

        //lay the bang slug
        Task<Tag> GetTagBySlugAsync(
            string slug, CancellationToken cancellationToken = default);

        //lay danh sach the kem theo so bai viet chua the do
        Task<IList<TagItem>> GetListTagWithPostCountAsync(CancellationToken cancellationToken = default);

        //Xoa mot ma theo the cho truoc
        Task DeleteTagById(int id, CancellationToken cancellationToken = default);

    }
}
