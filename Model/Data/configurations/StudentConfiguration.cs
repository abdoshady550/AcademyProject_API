using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AcademyProject_API.Model.Entities;

namespace AcademyProject_API.Model.Data.configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();




        }

    }
}
