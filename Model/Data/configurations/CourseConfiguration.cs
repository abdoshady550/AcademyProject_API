using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyProject_API.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyProject_API.Model.Data.configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.CourseName)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(x => x.Price)
                .HasColumnType("decimal")
                .HasPrecision(15, 2)
                .IsRequired();


        }

    }


}
