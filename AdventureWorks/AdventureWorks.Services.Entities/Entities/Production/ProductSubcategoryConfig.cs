//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class ProductSubcategoryConfig : IEntityTypeConfiguration<ProductSubcategory>
    {
        public void Configure(EntityTypeBuilder<ProductSubcategory> c)
        {
            c.ToTable("ProductSubcategory", "Production")
             .HasKey(e => e.ProductSubcategoryId);

            // configure relationships

            c.HasOne(e => e.ProductCategoryObject)
             .WithMany()
             .HasForeignKey(e => e.ProductCategoryId);

            // configure properties
          
            c.Property(e => e.ProductSubcategoryId)
             .HasColumnName("ProductSubcategoryID")
             .HasColumnType("int")
             .IsRequired()
             .ValueGeneratedOnAdd();

            c.Property(e => e.ProductCategoryId)
             .HasColumnName("ProductCategoryID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.Name)
             .HasColumnName("Name")
             .HasColumnType("nvarchar")
             .HasMaxLength(50)
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