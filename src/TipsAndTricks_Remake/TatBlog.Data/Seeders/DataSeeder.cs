using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{ //Lớp này tạo dữ liệu mẫu
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext; 
        //tạo một biến kiểu BlogDbContext để gán cho tham số trong hàm khơi tạo

        public DataSeeder(BlogDbContext dbContext)
            // khi tạo đối tượng dataseeder phải truyền một tham số kiểu BlogDbContext
        {
            _dbContext = dbContext;
            
        }

        

        //Hàm khởi tạo được imlement từ interface IdataSeeder
        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();
            if (_dbContext.Posts.Any()) return;
            //ktra db đã có thì không thêm vào
            
            var authors= AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts= AddPost(authors, categories, tags);
        }

        // Tạo các phương thức để tạo dữ liệu và thêm dữ liệu vào bảng

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName="BuiVanMot",
                    UrlSlug="Bui-Van-Mot",
                    Email="buivanmot@gmail.com",
                    JoinedDate= new DateTime(2023,1,1)
                },
                new()
                {
                    FullName="BuiVanHai",
                    UrlSlug="bui-van-hai",
                    Email="buivanhai@gmail.com",
                    JoinedDate= new DateTime(2022,1,2)
                },
                new()
                {
                    FullName="BuiVanBa",
                    UrlSlug="bui-van-ba",
                    Email="buivanba@gmail.com",
                    JoinedDate= new DateTime(2021,1,3)
                },
                new()
                {
                    FullName="BuiVanBon",
                    UrlSlug="bui-van-bon",
                    Email="buivanbon@gmail.com",
                    JoinedDate= new DateTime(2022,2,1)
                },
                new()
                {
                    FullName="BuiVanNam",
                    UrlSlug="bui-van-nam",
                    Email="buivannam@gmail.com",
                    JoinedDate= new DateTime(2023,2,2)
                },
                new()
                {
                    FullName="BuiVanSau",
                    UrlSlug="bui-van-sau",
                    Email="buivansau@gmail.com",
                    JoinedDate= new DateTime(2023,2,3)
                },
                new()
                {
                    FullName="BuiVanBay",
                    UrlSlug="bui-van-bay",
                    Email="buivanbay@gmail.com",
                    JoinedDate= new DateTime(2023,3,1)
                },
                new()
                {
                    FullName="BuiVanTam",
                    UrlSlug="bui-van-tam",
                    Email="buivantam@gmail.com",
                    JoinedDate= new DateTime(2023,4,1)
                }
            };
            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();
            return authors;
        }

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new (){Name = "Dart",Description = "Ngon ngu may tinh Dart", UrlSlug = "ngon-ngu-dart" },
                new (){Name = "CSharp",Description = "Ngon ngu may tinh CSharp", UrlSlug = "ngon-ngu-CSharp" },
                new (){Name = "JavaSCript",Description = "Ngon ngu may tinh JavaSCript", UrlSlug = "ngon-ngu-JavaSCript" },
                new (){Name = "Flutter",Description = "Framework flutter", UrlSlug = "framework-flutter" },
                new (){Name = ".NET",Description = "Framework .NET", UrlSlug = "framework-.NET" },
                new (){Name = "Spring",Description = "Framework Spring", UrlSlug = "framework-Spring" },
                new (){Name = "Build",Description = "Tinh nang build cua visual studio", UrlSlug = "tinh-nang-build" },
                new (){Name = "Run",Description = "Tinh nang run", UrlSlug = "tinh-nang-run" },
            };

            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }

        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new(){Name="Language",Description="Ngon Ngu",UrlSlug="ngon-ngu"},
                new(){Name="Framework",Description="Framework",UrlSlug="frame-work"},
                new(){Name="Librari",Description="Thu vien",UrlSlug="thu-vien"},
                new(){Name="Initialize",Description="Ham khoi tao",UrlSlug="ham-khoi-tao"},
                new(){Name="ClassMain",Description="Lop chinh",UrlSlug="lop-chinh"},
                new(){Name="SecClass",Description="Lop thu hai",UrlSlug="lop-thu-hai"},
                new(){Name="Third",Description="Lop thu ba",UrlSlug="lop-thu-ba"}
            };

            _dbContext.Tags.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }  


        private IList<Post> AddPost(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags
            )
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title="Hoc ngon ngu moi dart",
                    ShortDescription="Dart la ngon ngu may ting",
                    Description="Dart can duoc biet rong rai hon",
                    Meta="Du va Du cung hoc dart de thuc hien do an",
                    UrlSlug="Hoc-ngon-ngu-moi-dart",
                    IsPublished=true,
                    PostedDate=new DateTime(2023,4,26,8,21,15),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[1],
                    Category=categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[3],
                        tags[4],
                        tags[5]
                    }
                },
                new()
                {
                    Title="Flutter - Build apps for any screen",
                    ShortDescription="Flutter is an open source framework by Google for building beautiful, natively compiled, multi-platform applications from a single codebase",
                    Description="Flutter là một SDK phát triển ứng dụng di động nguồn mở được tạo ra bởi Google. Nó được sử dụng để phát triển ứng ứng dụng cho Android và iOS, cũng là phương thức chính để tạo ứng dụng cho Google",
                    Meta="Ngày phát hành đầu tiên: tháng 5 năm 2017",
                    UrlSlug="apps-for-any-screen-flutter",
                    IsPublished=true,
                    PostedDate=new DateTime(2023,3,11, 9,12,3),
                    ModifiedDate=null,
                    ViewCount=13,
                    Author=authors[0],
                    Category=categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[1],
                        tags[3]
                    }
                },
                new()
                {
                    Title="Giới thiệu về Spring Boot. Spring Boot là gì? - TopDev",
                    ShortDescription="Spring Boot là một dự án phát triển bởi JAV (ngôn ngữ java) trong hệ sinh thái Spring framework",
                    Description="Spring Boot là một dự án phát triển bởi JAV (ngôn ngữ java) trong hệ sinh thái Spring framework. Nó giúp cho các lập trình viên chúng ta đơn giản hóa quá trình lập trình một ứng dụng với Spring, chỉ tập trung vào việc phát triển business cho ứng dụng.",
                    Meta="Nó giúp cho các lập trình viên chúng ta đơn giản hóa quá trình lập trình một ứng dụng với Spring",
                    UrlSlug="gioi-thieu-ve-spring-boot",
                    IsPublished=true,
                    PostedDate=new DateTime(2023,1,26, 12,3,30),
                    ModifiedDate=null,
                    ViewCount=1,
                    Author=authors[5],
                    Category=categories[6],
                    Tags = new List<Tag>()
                    {
                        tags[6],
                        tags[2],
                        tags[0]
                    }
                },
                new()
                {
                    Title="About Instagram - Instagram Help Center",
                    ShortDescription="Instagram is a free photo and video sharing app available on iPhone and Android",
                    Description="Instagram là một dịch vụ mạng xã hội chia sẻ hình ảnh và video của Mỹ được tạo ra bởi Kevin Systrom và Mike Krieger. Vào tháng 4 năm 2012, Facebook đã mua lại dịch vụ này với giá khoảng 1 tỷ đô la Mỹ bằng tiền mặt và cổ phiếu",
                    Meta="Instagram",
                    UrlSlug="about-instagram-instagram-help-center",
                    IsPublished=true,
                    PostedDate=new DateTime(2012, 2, 4, 6, 12, 5),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[3],
                    Category=categories[4],
                    Tags = new List<Tag>()
                    {
                        tags[6],
                        tags[1],
                        tags[5]
                    }
                },
                new()
                {
                    Title="What is ChatGPT and why does it matter",
                    ShortDescription="What is ChatGPT and why does it matter",
                    Description="What is ChatGPT and why does it matter",
                    Meta="What is ChatGPT and why does it matter",
                    UrlSlug="what-is-chatgpt-and-why-does-it-matter",
                    IsPublished=true,
                    PostedDate=new DateTime(2012, 12, 4, 6, 30, 3),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[4],
                    Category=categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[4],
                        tags[5],
                    }
                },
                new()
                {
                    Title="Introduction - Apache Maven",
                    ShortDescription="Introduction - Apache Maven",
                    Description="Introduction - Apache Maven",
                    Meta="Introduction - Apache Maven",
                    UrlSlug="introduction-apache-maven",
                    IsPublished=true,
                    PostedDate=new DateTime(2023, 6, 3, 8, 45, 56),
                    ModifiedDate=null,
                    ViewCount=20,
                    Author=authors[1],
                    Category=categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                },
                new()
                {
                    Title="What is Jenkins and How Does It Work",
                    ShortDescription="What is Jenkins and How Does It Work",
                    Description="What is Jenkins and How Does It Work",
                    Meta="What is Jenkins and How Does It Work",
                    UrlSlug="what-is-jenkins-and-how-does-it-work",
                    IsPublished=true,
                    PostedDate =new DateTime(2022 , 4, 23, 2, 25, 35),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[4],
                    Category=categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[3],
                        tags[5],
                        tags[1]
                    }
                },
            };
            _dbContext.Posts.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }
    }
}
