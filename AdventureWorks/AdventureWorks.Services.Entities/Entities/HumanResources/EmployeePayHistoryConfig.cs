//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class EmployeePayHistoryConfig : IEntityTypeConfiguration<EmployeePayHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeePayHistory> c)
        {
            c.ToTable("EmployeePayHistory", "HumanResources")
             .HasKey(e => new { e.BusinessEntityId, e.RateChangeDate });

            // configure relationships

            c.HasOne(e => e.BusinessEntityObject)
             .WithMany()
             .HasForeignKey(e => e.BusinessEntityId);

            // configure properties
          
            c.Property(e => e.BusinessEntityId)
             .HasColumnName("BusinessEntityID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.RateChangeDate)
             .HasColumnName("RateChangeDate")
             .HasColumnType("datetime")
             .IsRequired();

            c.Property(e => e.Rate)
             .HasColumnName("Rate")
             .HasColumnType("money")
             .IsRequired();

            c.Property(e => e.PayFrequency)
             .HasColumnName("PayFrequency")
             .HasColumnType("tinyint")
             .IsRequired();

            c.Property(e => e.ModifiedDate)
             .HasColumnName("ModifiedDate")
             .HasColumnType("datetime")
             .IsRequired();

        }
    }
}