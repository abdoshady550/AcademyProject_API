using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyProject_API.Model.Entities;
using AcademyProject_API.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyProject_API.Model.Data.configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasConversion(
                x => x.ToString(),
                x => (ScheduleEnum)Enum.Parse(typeof(ScheduleEnum), x)
                );

            builder.ToTable("Schedule");

        }

    }
}
