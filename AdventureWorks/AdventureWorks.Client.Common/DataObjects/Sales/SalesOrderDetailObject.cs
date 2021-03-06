//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Xomega Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Properties;
using Xomega.Framework.Services;

namespace AdventureWorks.Client.Objects
{
    public partial class SalesOrderDetailObject : DataObject
    {
        #region Constants

        public const string CarrierTrackingNumber = "CarrierTrackingNumber";
        public const string LineTotal = "LineTotal";
        public const string OrderQty = "OrderQty";
        public const string ProductId = "ProductId";
        public const string SalesOrderDetailId = "SalesOrderDetailId";
        public const string SalesOrderId = "SalesOrderId";
        public const string SpecialOfferId = "SpecialOfferId";
        public const string Subcategory = "Subcategory";
        public const string UnitPrice = "UnitPrice";
        public const string UnitPriceDiscount = "UnitPriceDiscount";

        #endregion

        #region Properties

        public TextProperty CarrierTrackingNumberProperty { get; private set; }
        public MoneyProperty LineTotalProperty { get; private set; }
        public PositiveSmallIntProperty OrderQtyProperty { get; private set; }
        public EnumIntProperty ProductIdProperty { get; private set; }
        public IntegerKeyProperty SalesOrderDetailIdProperty { get; private set; }
        public IntegerKeyProperty SalesOrderIdProperty { get; private set; }
        public EnumIntProperty SpecialOfferIdProperty { get; private set; }
        public EnumIntProperty SubcategoryProperty { get; private set; }
        public MoneyProperty UnitPriceProperty { get; private set; }
        public PercentFractionProperty UnitPriceDiscountProperty { get; private set; }

        #endregion

        #region Construction

        public SalesOrderDetailObject()
        {
        }

        public SalesOrderDetailObject(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Initialize()
        {
            SalesOrderDetailIdProperty = new IntegerKeyProperty(this, SalesOrderDetailId)
            {
                Required = true,
                Editable = false,
                IsKey = true,
            };
            SalesOrderIdProperty = new IntegerKeyProperty(this, SalesOrderId)
            {
                Required = true,
                Editable = false,
            };
            SubcategoryProperty = new EnumIntProperty(this, Subcategory)
            {
                EnumType = "product subcategory",
            };
            ProductIdProperty = new EnumIntProperty(this, ProductId)
            {
                Required = true,
                EnumType = "product",
            };
            OrderQtyProperty = new PositiveSmallIntProperty(this, OrderQty)
            {
                Required = true,
            };
            SpecialOfferIdProperty = new EnumIntProperty(this, SpecialOfferId)
            {
                Required = true,
                EnumType = "special offer",
            };
            UnitPriceProperty = new MoneyProperty(this, UnitPrice)
            {
                Required = true,
                Editable = false,
            };
            UnitPriceDiscountProperty = new PercentFractionProperty(this, UnitPriceDiscount)
            {
                Required = true,
                Editable = false,
            };
            LineTotalProperty = new MoneyProperty(this, LineTotal)
            {
                Required = true,
                Editable = false,
            };
            CarrierTrackingNumberProperty = new TextProperty(this, CarrierTrackingNumber)
            {
                Size = 25,
            };
        }

        #endregion

        #region CRUD Operations

        protected override async Task<ErrorList> DoReadAsync(object options, CancellationToken token = default)
        {
            var output = await SalesOrder_Detail_ReadAsync(options);
            return output.Messages;
        }

        protected override async Task<ErrorList> DoSaveAsync(object options, CancellationToken token = default)
        {
            if (IsNew)
            {
                var output = await SalesOrder_Detail_CreateAsync(options);
                return output.Messages;
            }
            else
            {
                var output = await SalesOrder_Detail_UpdateAsync(options);
                return output.Messages;
            }
        }

        protected override async Task<ErrorList> DoDeleteAsync(object options, CancellationToken token = default)
        {
            var output = await SalesOrder_Detail_DeleteAsync(options);
            return output.Messages;
        }

        #endregion

        #region Service Operations

        protected virtual async Task<Output<SalesOrderDetail_ReadOutput>> SalesOrder_Detail_ReadAsync(object options)
        {
            int _salesOrderDetailId = (int)SalesOrderDetailIdProperty.TransportValue;
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().Detail_ReadAsync(_salesOrderDetailId);

                await FromDataContractAsync(output?.Result, options);
                return output;
            }
        }

        protected virtual async Task<Output<SalesOrderDetail_CreateOutput>> SalesOrder_Detail_CreateAsync(object options)
        {
            int _salesOrderId = (int)SalesOrderIdProperty.TransportValue;
            SalesOrderDetail_CreateInput_Data _data = ToDataContract<SalesOrderDetail_CreateInput_Data>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().Detail_CreateAsync(_salesOrderId, _data);

                await FromDataContractAsync(output?.Result, options);
                return output;
            }
        }

        protected virtual async Task<Output> SalesOrder_Detail_UpdateAsync(object options)
        {
            int _salesOrderDetailId = (int)SalesOrderDetailIdProperty.TransportValue;
            SalesOrderDetail_UpdateInput_Data _data = ToDataContract<SalesOrderDetail_UpdateInput_Data>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().Detail_UpdateAsync(_salesOrderDetailId, _data);

                return output;
            }
        }

        protected virtual async Task<Output> SalesOrder_Detail_DeleteAsync(object options)
        {
            int _salesOrderDetailId = (int)SalesOrderDetailIdProperty.TransportValue;
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().Detail_DeleteAsync(_salesOrderDetailId);

                return output;
            }
        }

        #endregion
    }
}