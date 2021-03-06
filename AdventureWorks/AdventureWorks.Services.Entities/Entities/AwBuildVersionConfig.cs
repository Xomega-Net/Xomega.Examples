//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class AwBuildVersionConfig : IEntityTypeConfiguration<AwBuildVersion>
    {
        public void Configure(EntityTypeBuilder<AwBuildVersion> c)
        {
            c.ToTable("AWBuildVersion")
             .HasKey(e => e.SystemInformationId);

            // configure properties
          
            c.Property(e => e.SystemInformationId)
             .HasColumnName("SystemInformationID")
             .HasColumnType("tinyint")
             .IsRequired()
             .ValueGeneratedOnAdd();

            c.Property(e => e.DatabaseVersion)
             .HasColumnName("Database Version")
             .HasColumnType("nvarchar")
             .HasMaxLength(25)
             .IsUnicode()
             .IsRequired();

            c.Property(e => e.VersionDate)
             .HasColumnName("VersionDate")
             .HasColumnType("datetime")
             .IsRequired();

            c.Property(e => e.ModifiedDate)
             .HasColumnName("ModifiedDate")
             .HasColumnType("datetime")
             .IsRequired();

        }
    }
}