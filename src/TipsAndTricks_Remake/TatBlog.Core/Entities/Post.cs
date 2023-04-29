using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    //Lớp này biễu diễn một bài viết của Blog
    //Các thuộc tính cần có:
    //      mã, tiêu đề, mô tả, mô tả ngắn, metadata, tên định danh tạo url,
    //      đường dẫn hình ảnh, số lượt xem, trạng thái(xuất bản hay chưa), ngày đăng, ngày cập nhật,
    //      mã chuyên mục, mã tác giả, chuyên mục bài viết, tác giả bài viết, Danh sách từ khóa
    
    public class Post : IEntity
    {
        public int Id { get; set; }//property

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Meta { get; set; }

        public string UrlSlug { get; set; }

        public string ImageUrl { get; set; }

        public int ViewCount { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PostedDate { get; set; }

        public DateTime? ModifiedDate { get; set;} //allow null

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public Category Category { get; set; }

        public Author Author { get; set; }

        public List<Tag> Tags { get; set; }
   
    }
}
