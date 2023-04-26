using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;

namespace TatBlog.Data.Mappings
{
    // Định nghĩa các ràng buộc và ánh xạ các lớp(và các thuộc tính) ở trên thành các bảng(và các cột)
    //  trong cơ sở dữ liệu
    public class CategoryMap : IEntityTypeConfiguration<Category>   //cấu hình trên đối tượng<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x=>x.UrlSlug) 
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ShowOnMenu)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
