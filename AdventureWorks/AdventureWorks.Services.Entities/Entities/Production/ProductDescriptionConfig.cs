//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class ProductDescriptionConfig : IEntityTypeConfiguration<ProductDescription>
    {
        public void Configure(EntityTypeBuilder<ProductDescription> c)
        {
            c.ToTable("ProductDescription", "Production")
             .HasKey(e => e.ProductDescriptionId);

            // configure properties
          
            c.Property(e => e.ProductDescriptionId)
             .HasColumnName("ProductDescriptionID")
             .HasColumnType("int")
             .IsRequired()
             .ValueGeneratedOnAdd();

            c.Property(e => e.Description)
             .HasColumnName("Description")
             .HasColumnType("nvarchar")
             .HasMaxLength(400)
             .IsUnicode()
             .IsRequired();

            c.Property(e => e.Rowguid)
             .HasColumnName("rowguid")
             .HasColumnType("uniqueidentifier")
             .IsRequired();

            c.Property(e => e.ModifiedDate)
             .HasColumnName("ModifiedDate")
             .HasColumnType("datetime")
             .IsRequired();

        }
    }
}