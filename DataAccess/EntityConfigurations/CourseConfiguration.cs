using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CategoryId).HasColumnName("CategoryId").IsRequired();
            builder.Property(b => b.InstructorId).HasColumnName("InstructorId").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
            builder.Property(b => b.Price).HasColumnName("Price").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Courses_Name").IsUnique();

            builder.HasOne(b => b.Category);
            builder.HasOne(b => b.Instructor);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //default filtre koymak için bunu kullanırız.
        }
    }
}
