using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    //Lớp này biểu diễn tác giả của một bài viết
    public class Author : IEntity
    {
        //Các thuộc tính của tác giả bao gồm:

        //Mã tác giả: Id 
        public int Id { get; set; } 

        //Tên tác giả: FullName
        public string FullName { get; set; }

        //Tên định danh để tạo URL: UrlSlug
        public string UrlSlug { get; set; }

        //Đường dẫn tới file hình ảnh: UrlImage
        public string UrlImage { get; set; }

        //Ngày bắt đầu (Do là ngày nên dùng kiểu DateTime)
        public DateTime JoinedDate { get; set; }

        //Email của tác giả: Email
        public string Email { get; set; }

        //Ghi chú: Notes 
        public string Notes { get; set; }

        //Danh sách các bài post của tác giả: Posts
        public List<Post> Posts { get; set; }
    }
}
