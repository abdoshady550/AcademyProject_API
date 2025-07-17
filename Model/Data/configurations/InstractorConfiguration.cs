using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AcademyProject_API.Model.Entities;

namespace AcademyProject_API.Model.Data.configurations
{
    public class InstractorConfiguration : IEntityTypeConfiguration<Instractor>
    {
        public void Configure(EntityTypeBuilder<Instractor> builder)
        {
            builder.ToTable("Instractors");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Fname)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Lname)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.office)
                .WithOne(e => e.instractor)
                .HasForeignKey<Instractor>(x => x.officeId)
                .IsRequired(false);



        }

    }
}
