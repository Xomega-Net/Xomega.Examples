
import { SalesOrderDetailObject as GeneratedDataObject } from 'DataObjects/Sales/SalesOrderDetailObject';
import { SpecialOfferProductReadListCacheLoader } from '../../CacheLoaders/SpecialOfferProductReadListCacheLoader';
import { SpecialOfferProduct, Product } from '../../Enumerations/Enumerations';
import { Header } from 'xomega';

export class SalesOrderDetailObject extends GeneratedDataObject {

    // construct properties and child objects
    init() {
        super.init();
        // add custom construction code here
    }

    // perform post intialization
    onInitialized() {
        this.ProductId.setCascadingProperty(Product.Attributes.ProductSubcategoryId, this.Subcategory);
        this.ProductId.cascadingMatchNulls = true; // blank subcategory will display products with no categories
        this.ProductId.InternalValue.subscribe(() => {
            var hdr: Header = this.ProductId.InternalValue();
            if (hdr) this.UnitPrice.InternalValue(hdr.getAttribute(Product.Attributes.ListPrice));
            this.updateLineTotal();
        });

        this.SpecialOfferId.LocalCacheLoader = new SpecialOfferProductReadListCacheLoader();
        this.SpecialOfferId.setCacheLoaderParameters(SpecialOfferProduct.Parameters.ProductId, this.ProductId);
        this.SpecialOfferId.InternalValue.subscribe(() => {
            var hdr: Header = this.SpecialOfferId.InternalValue();
            if (hdr) this.UnitPriceDiscount.InternalValue(hdr.getAttribute(SpecialOfferProduct.Attributes.Discount));
            this.updateLineTotal();
        });

        this.OrderQty.InternalValue.subscribe(() => this.updateLineTotal());

        super.onInitialized();
    }

    updateLineTotal() {
        var price = this.UnitPrice.InternalValue() || 0;
        var qty = this.OrderQty.InternalValue() || 0;
        var discount = this.UnitPriceDiscount.InternalValue() || 0;
        this.LineTotal.InternalValue(price * (1 - discount) * qty);
    }
}