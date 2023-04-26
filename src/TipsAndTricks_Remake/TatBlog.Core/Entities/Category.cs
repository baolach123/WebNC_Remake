using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{ 
    //Lớp này để biểu diễn chuyên mục hay chủ đề
    public class Category : IEntity
    {
        //Chủ đề gồm có các thuộc tính như sau:

        //    Mã chuyên mục: Id
        public int Id { get; set; }

        //    Tên chuyên mục: Name
        public string Name { get; set; }

        //    Tên định danh để tạo URL: UrlSlug
        public string UrlSlug { get; set; }

        //    Mô tả về chuyên mục: Description
        public string Description { get; set; }

        //    Đánh dấu chuyên mục được hiển thị trên menu: ShowOneMenu (Kiểu bool)
        public bool ShowOnMenu { get; set; }

        //    Danh sách(List) các bài viết thuộc chuyên mục: Posts
        //    (Danh sách các post nên kiểu trả về là <Post>)      
        public List<Post> Posts { get; set; }

    }
}
