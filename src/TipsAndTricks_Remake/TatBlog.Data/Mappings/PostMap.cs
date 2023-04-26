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
    public class PostMap : IEntityTypeConfiguration<Post> //cấu hình trên đối tượng<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder) 
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Title)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x=>x.ShortDescription)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(x=>x.UrlSlug)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x=>x.Meta)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(1000);

            builder.Property(x => x.ViewCount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x=>x.IsPublished)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.PostedDate)
                .HasColumnType("datetime");
            // khai báo cho db biết kiểu dữ liệu datetime vì db sẽ có nhiều kiểu datetime khác nhau

            builder.Property(x => x.ModifiedDate)
                .HasColumnType("datetime");
            // khai báo cho db biết kiểu dữ liệu datetime vì db sẽ có nhiều kiểu datetime khác nhau

            builder.HasOne(x=>x.Category)
                .WithMany(p=>p.Posts)
                .HasForeignKey(p=>p.CategoryId)
                .HasConstraintName("FK_Posts_Categories")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x=>x.Author)
                .WithMany(p=>p.Posts)
                .HasForeignKey(p=>p.AuthorId)
                .HasConstraintName("FK_Posts_Authors")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(p => p.Posts)
                .UsingEntity(pt => pt.ToTable("PostTags"));
        }
    }
}
