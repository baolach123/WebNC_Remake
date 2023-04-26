using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

    public class TagMap : IEntityTypeConfiguration<Tag> //cấu hình trên đối tượng<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            //cấu hình cho tag

            builder.ToTable("Tags");    //Tên bảng

            builder.HasKey(t => t.Id);  //Khóa chính

            builder.Property(t => t.Name)   //set các thuộc tính cho các trường dữ liệu
                .HasMaxLength(50) //max 50 ký tự
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(500);

            builder.Property(t=>t.UrlSlug)
                .HasMaxLength (50)
                .IsRequired();

        }
    }
}
