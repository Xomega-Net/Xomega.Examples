using AdventureWorks.Services;
using System;

namespace AdventureWorks.Client.Objects
{
    public class SalesOrderObjectCustomized : SalesOrderObject
    {
        public SalesOrderObjectCustomized()
        {
        }

        public SalesOrderObjectCustomized(IServiceProvider serviceProvider) : base(serviceProvider)
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

            var ccProperty = PaymentObject.CreditCardObject.CreditCardIdProperty;
            ccProperty.LocalCacheLoader = new PersonCreditCardReadListCacheLoader(ServiceProvider);
            ccProperty.SetCacheLoaderParameters(Enumerations.PersonCreditCard.Parameters.BusinessEntityId, CustomerObject.PersonIdProperty);
        }

        // add custom code here
    }
}