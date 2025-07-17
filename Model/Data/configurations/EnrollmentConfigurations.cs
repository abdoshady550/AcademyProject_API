using AcademyProject_API.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyProject_API.Model.Data.configurations
{
    public class EnrollmentConfigurations : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");

            builder.HasKey(x => new { x.SectionId, x.StudentId });




        }

    }

}
