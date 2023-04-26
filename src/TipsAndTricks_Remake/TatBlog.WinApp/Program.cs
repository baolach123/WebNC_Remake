using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;

//Tạo đối tượng DBContext để quản lý phiên làm việc với db và trạng thái của các đối tượng
var context = new BlogDbContext();

//Đối tượng khởi tạo dữ liệu mẫu
 var seeder = new DataSeeder(context);

//Gọi hàm khởi tạo (initialize) để nhập dữ liệu mẫu
seeder.Initialize();

//Đọc danh sách tác giả từ database
var authors = context.Authors.ToList();

//Xuất ra màn hình
Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12}", "ID", "Full Name", "Email", "Joined Date");
 foreach(var author in authors)
{
    Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12:MM/dd//yyyy}",
                        author.Id,author.FullName,author.Email,author.JoinedDate);
}


