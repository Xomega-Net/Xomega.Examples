
import { SalesOrderCustomerObject as GeneratedDataObject } from 'DataObjects/Sales/SalesOrderCustomerObject';
import { BusinessEntityAddressReadListCacheLoader } from '../../CacheLoaders/BusinessEntityAddressReadListCacheLoader';
import { BusinessEntityAddress } from '../../Enumerations/Enumerations';

export class SalesOrderCustomerObject extends GeneratedDataObject {

    private addressLoader: BusinessEntityAddressReadListCacheLoader;

    onInitialized() {
        this.LookupObject.TrackModifications = false;

        this.addressLoader = new BusinessEntityAddressReadListCacheLoader();
        this.BillingAddressObject.AddressId.LocalCacheLoader = this.addressLoader;
        this.ShippingAddressObject.AddressId.LocalCacheLoader = this.addressLoader;

        this.StoreId.InternalValue.subscribe(this.onCustomerChanged, this);
        this.PersonId.InternalValue.subscribe(this.onCustomerChanged, this);

        super.onInitialized();
    }

    onCustomerChanged() {
        if (this.PersonId.isNull() && this.StoreId.isNull()) return;

        var newParams = {};
        newParams[BusinessEntityAddress.Parameters.BusinessEntityId] = this.StoreId.isNull() ?
            this.PersonId.TransportValue() : this.StoreId.TransportValue();
        this.addressLoader.setParameters(newParams, () => {
            this.BillingAddressObject.AddressId.clearInvalidValues();
            this.ShippingAddressObject.AddressId.clearInvalidValues();
            this.BillingAddressObject.AddressId.updateValueList();
            this.ShippingAddressObject.AddressId.updateValueList();
        });
    }
}