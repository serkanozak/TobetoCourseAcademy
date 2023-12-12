using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Instructors_Name").IsUnique();

            builder.HasMany(b => b.Courses);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //default filtre koymak için bunu kullanırız.
        }
    }
}
