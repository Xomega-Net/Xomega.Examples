//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class PersonCreditCardConfig : IEntityTypeConfiguration<PersonCreditCard>
    {
        public void Configure(EntityTypeBuilder<PersonCreditCard> c)
        {
            c.ToTable("PersonCreditCard", "Sales")
             .HasKey(e => new { e.BusinessEntityId, e.CreditCardId });

            // configure relationships

            c.HasOne(e => e.BusinessEntityObject)
             .WithMany()
             .HasForeignKey(e => e.BusinessEntityId);

            c.HasOne(e => e.CreditCardObject)
             .WithMany()
             .HasForeignKey(e => e.CreditCardId);

            // configure properties
          
            c.Property(e => e.BusinessEntityId)
             .HasColumnName("BusinessEntityID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.CreditCardId)
             .HasColumnName("CreditCardID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.ModifiedDate)
             .HasColumnName("ModifiedDate")
             .HasColumnType("datetime")
             .IsRequired();

        }
    }
}