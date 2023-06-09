﻿using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.WinApp;

//Tạo đối tượng DBContext để quản lý phiên làm việc với db và trạng thái của các đối tượng
var context = new BlogDbContext();

//Đối tượng khởi tạo dữ liệu mẫuu
 var seeder = new DataSeeder(context);



//Tạo đối tượng BlogRepository để sử dụng hàm trong class
IBlogRepository repository = new BlogRepository(context);
//Gọi hàm khởi tạo (initialize) để nhập dữ liệu mẫu
seeder.Initialize();

//Đọc danh sách tác giả từ database
var authors = context.Authors.ToList();


var pagingParams = new PagingParams
{
    PageNumber = 1,
    PageSize = 5,
    SortColumn = "Name",
    SortOrder = "DESC"
};

var tagList = await repository.GetPagedTagsAsync(pagingParams);

Console.WriteLine("{0,-5}{1,-50}{2,-10}","ID","Name","Count");

foreach(var tag in tagList)
{
    Console.WriteLine("{0,-5}{1,-50}{2,-10}",tag.Id,tag.Name,tag.PostCount);
}

//Xuất ra màn hình
Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12}", "ID", "Full Name", "Email", "Joined Date");
foreach (var author in authors)
{
    Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12:MM/dd//yyyy}",
                        author.Id, author.FullName, author.Email, author.JoinedDate);
}

Console.WriteLine("".PadRight(80, '-'));


//Đọc danh sách bài viết trong csdl, lấy cả author và chuyên mục

var posts = context.Posts
    .Where(p => p.IsPublished)
    .OrderBy(p => p.Id)
    .Select(p => new
    {
        Id = p.Id,
        Title = p.Title,
        ViewCount = p.ViewCount,
        PostedDate = p.PostedDate,
        Author = p.Author.FullName,
        Category = p.Category.Name,

    }).ToList();

//Xuất danh sách bài viết ra màn hình

foreach (var post in posts)
{
    Console.WriteLine("ID               : {0}", post.Id);
    Console.WriteLine("Title            : {0}", post.Title);
    Console.WriteLine("ViewCount        : {0}", post.ViewCount);
    Console.WriteLine("PostedDate       : {0:MM/dd/yyyy}", post.PostedDate);
    Console.WriteLine("Author           : {0}", post.Author);
    Console.WriteLine("Category         : {0}", post.Category);
    Console.WriteLine("".PadRight(80, '-'));
}


//Tìm bài viết theo slug,month,year
var postsMYS = await repository.GetPostBySlugMonthYearAsync(2023, 4, "Hoc-ngon-ngu-moi-dart");
Console.WriteLine("{0,-25}{1,-50}{2,-50}", postsMYS.Title, postsMYS.Meta, postsMYS.ShortDescription);


//Lấy n post nhiều view nhất
var listPost = await repository.GetPostsMostWatch(2);
foreach (var post in listPost)
{
    Console.WriteLine("ID               : {0}", post.Id);
    Console.WriteLine("Title            : {0}", post.Title);
    Console.WriteLine("ViewCount        : {0}", post.ViewCount);
    Console.WriteLine("PostedDate       : {0:MM/dd/yyyy}", post.PostedDate);
    Console.WriteLine("Author           : {0}", post.Author);
    Console.WriteLine("Category         : {0}", post.Category);
    Console.WriteLine("".PadRight(80, '-'));
}


var check = repository.IsHasSlugInPost(1, "Chuoi random");

//if(check==true)
//{
//    Console.WriteLine("");
//}

////Lấy list category và đếm số bài viết trong category
var listCategories = await repository.GetCategoriesAsync();

foreach (var category in listCategories)
{
    Console.WriteLine("{0,-20}{1,-4}",category.Name,category.PostCount);
}
