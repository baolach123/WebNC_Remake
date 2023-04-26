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
    public class AuthorMap : IEntityTypeConfiguration<Author>   //cấu hình trên đối tượng<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");// Ten bang

            builder.HasKey(x => x.Id);// set khoa chinh

            builder.Property(x => x.FullName)
                .IsRequired()   //ràng buộc not null
                .HasMaxLength(100);

            builder.Property(x => x.UrlSlug)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.UrlImage)
                .HasMaxLength(500);

            builder.Property(x=>x.Email) 
                .HasMaxLength(500);

            builder.Property(x => x.JoinedDate)
                .HasColumnType("datetime");
            // khai báo cho db biết kiểu dữ liệu datetime vì db sẽ có nhiều kiểu datetime khác nhau

            builder.Property(a=>a.Notes)
                .HasMaxLength (500);
        }
    }
}
