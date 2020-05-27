using AdventureWorks.Services;
using System;
using System.Collections.Generic;
using Xomega.Framework;
using Xomega.Framework.Lookup;

namespace AdventureWorks.Client.Objects
{
    public class SalesOrderCustomerObjectCustomized : SalesOrderCustomerObject
    {
        public SalesOrderCustomerObjectCustomized()
        {
        }

        public SalesOrderCustomerObjectCustomized(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        // construct properties and child objects
        protected override void Initialize()
        {
            base.Initialize();
        }

        private LocalLookupCacheLoader AddressLoader;

        // perform post intialization
        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddressLoader = new BusinessEntityAddressReadListCacheLoader(ServiceProvider);
            BillingAddressObject.AddressIdProperty.LocalCacheLoader = AddressLoader;
            ShippingAddressObject.AddressIdProperty.LocalCacheLoader = AddressLoader;

            StoreIdProperty.Change += OnCustomerChanged;
            PersonIdProperty.Change += OnCustomerChanged;
        }

        private void OnCustomerChanged(object sender, PropertyChangeEventArgs e)
        {
            if (!e.Change.IncludesValue() || Equals(e.OldValue, e.NewValue) ||
                PersonIdProperty.Value == null && StoreIdProperty.Value == null) return;

            int entityId = StoreIdProperty.Value == null ? // use store or person id
                PersonIdProperty.Value.Value : StoreIdProperty.Value.Value;

            AddressLoader.SetParameters(new Dictionary<string, object>() {
                { Enumerations.BusinessEntityAddress.Parameters.BusinessEntityId, entityId }
            });

            BillingAddressObject.AddressIdProperty.ClearInvalidValues();
            ShippingAddressObject.AddressIdProperty.ClearInvalidValues();

            var args = new PropertyChangeEventArgs(PropertyChange.Items, null, null, e.Row);
            BillingAddressObject.AddressIdProperty.FirePropertyChange(args);
            ShippingAddressObject.AddressIdProperty.FirePropertyChange(args);
        }
    }
}