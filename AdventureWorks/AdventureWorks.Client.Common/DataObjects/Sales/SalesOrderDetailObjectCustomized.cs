using AdventureWorks.Services;
using System;
using Xomega.Framework;

namespace AdventureWorks.Client.Objects
{
    public class SalesOrderDetailObjectCustomized : SalesOrderDetailObject
    {
        public SalesOrderDetailObjectCustomized()
        {
        }

        public SalesOrderDetailObjectCustomized(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        // construct properties and child objects
        protected override void Initialize()
        {
            base.Initialize();
            // add custom construction code here
        }

        // perform post intialization
        protected override void OnInitialized()
        {
            base.OnInitialized();

            ProductIdProperty.SetCascadingProperty(Enumerations.Product.Attributes.ProductSubcategoryId, SubcategoryProperty);
            ProductIdProperty.CascadingMatchNulls = true; // blank subcategory will display products with no categories
            ProductIdProperty.Change += (sender, e) =>
            {
                if (e.Change.IncludesValue() && !ProductIdProperty.IsNull())
                {
                    UnitPriceProperty.SetValue(ProductIdProperty.Value[Enumerations.Product.Attributes.ListPrice]);
                    UpdateLineTotal(sender, e);
                }
            };

            SpecialOfferIdProperty.LocalCacheLoader = new SpecialOfferProductReadListCacheLoader(ServiceProvider);
            SpecialOfferIdProperty.SetCacheLoaderParameters(Enumerations.SpecialOfferProduct.Parameters.ProductId, ProductIdProperty);
            SpecialOfferIdProperty.Change += (sender, e) =>
            {
                if (e.Change.IncludesValue() && !SpecialOfferIdProperty.IsNull())
                {
                    UnitPriceDiscountProperty.SetValue(SpecialOfferIdProperty.Value[Enumerations.SpecialOfferProduct.Attributes.Discount]);
                    UpdateLineTotal(sender, e);
                }
            };
            OrderQtyProperty.Change += UpdateLineTotal;
        }

        private void UpdateLineTotal(object sender, PropertyChangeEventArgs e)
        {
            if (e.Change.IncludesValue())
            {
                var price = UnitPriceProperty.Value ?? 0;
                var qty = OrderQtyProperty.Value ?? 0;
                var discount = UnitPriceDiscountProperty.Value ?? 0;
                LineTotalProperty.SetValue(price * (1 - discount) * qty);
            }
        }
    }
}