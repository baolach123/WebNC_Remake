using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    //Lớp này để biểu diễn từ khóa trong bài viết
    public class Tag : IEntity
    {
        //Mã tag
        public int Id { get; set; }
        
        //Tên tag
        public string Name { get; set; } //Kiểu string măc dinh allow null

        //Tên định danh
        public string UrlSlug { get; set; }

        //Mô tả của tag
        public string Description { get; set; }

        //Danh sách các bài viết chứa tag
        public List<Post> Posts { get; set; }
    }
}
