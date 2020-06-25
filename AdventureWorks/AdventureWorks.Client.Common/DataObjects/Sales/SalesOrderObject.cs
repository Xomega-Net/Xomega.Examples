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
    public partial class SalesOrderObject : DataObject
    {
        #region Constants

        public const string AccountNumber = "AccountNumber";
        public const string Comment = "Comment";
        public const string Customer = "Customer";
        public const string Detail = "Detail";
        public const string ModifiedDate = "ModifiedDate";
        public const string OnlineOrderFlag = "OnlineOrderFlag";
        public const string OrderDate = "OrderDate";
        public const string Payment = "Payment";
        public const string PurchaseOrderNumber = "PurchaseOrderNumber";
        public const string RevisionNumber = "RevisionNumber";
        public const string Sales = "Sales";
        public const string SalesOrderId = "SalesOrderId";
        public const string SalesOrderNumber = "SalesOrderNumber";
        public const string ShipDate = "ShipDate";
        public const string Status = "Status";

        #endregion

        #region Properties

        public TextProperty AccountNumberProperty { get; private set; }
        public TextProperty CommentProperty { get; private set; }
        public DateTimeProperty ModifiedDateProperty { get; private set; }
        public BooleanProperty OnlineOrderFlagProperty { get; private set; }
        public DateProperty OrderDateProperty { get; private set; }
        public TextProperty PurchaseOrderNumberProperty { get; private set; }
        public TinyIntegerProperty RevisionNumberProperty { get; private set; }
        public IntegerKeyProperty SalesOrderIdProperty { get; private set; }
        public TextProperty SalesOrderNumberProperty { get; private set; }
        public DateProperty ShipDateProperty { get; private set; }
        public EnumByteProperty StatusProperty { get; private set; }

        #endregion

        #region Child Objects

        public SalesOrderCustomerObject CustomerObject { get { return (SalesOrderCustomerObject)GetChildObject(Customer); } }
        public SalesOrderDetailList DetailList { get { return (SalesOrderDetailList)GetChildObject(Detail); } }
        public SalesOrderPaymentObject PaymentObject { get { return (SalesOrderPaymentObject)GetChildObject(Payment); } }
        public SalesOrderSalesObject SalesObject { get { return (SalesOrderSalesObject)GetChildObject(Sales); } }

        #endregion

        #region Construction

        public SalesOrderObject()
        {
        }

        public SalesOrderObject(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Initialize()
        {
            AccountNumberProperty = new TextProperty(this, AccountNumber)
            {
                Size = 15,
            };
            CommentProperty = new TextProperty(this, Comment)
            {
                Size = 128,
            };
            ModifiedDateProperty = new DateTimeProperty(this, ModifiedDate)
            {
                Required = true,
                Editable = false,
            };
            OnlineOrderFlagProperty = new BooleanProperty(this, OnlineOrderFlag)
            {
                Required = true,
            };
            OrderDateProperty = new DateProperty(this, OrderDate)
            {
                Required = true,
                Editable = false,
            };
            PurchaseOrderNumberProperty = new TextProperty(this, PurchaseOrderNumber)
            {
                Size = 25,
            };
            RevisionNumberProperty = new TinyIntegerProperty(this, RevisionNumber)
            {
                Required = true,
                Editable = false,
            };
            SalesOrderIdProperty = new IntegerKeyProperty(this, SalesOrderId)
            {
                Required = true,
                Editable = false,
                IsKey = true,
            };
            SalesOrderNumberProperty = new TextProperty(this, SalesOrderNumber)
            {
                Required = true,
                Size = 25,
                Editable = false,
            };
            ShipDateProperty = new DateProperty(this, ShipDate)
            {
            };
            StatusProperty = new EnumByteProperty(this, Status)
            {
                Required = true,
                EnumType = "sales order status",
            };
            DataObject objCustomer = ServiceProvider.GetService<SalesOrderCustomerObject>();
            AddChildObject(Customer, objCustomer);
            DataObject objDetail = ServiceProvider.GetService<SalesOrderDetailList>();
            AddChildObject(Detail, objDetail);
            DataObject objPayment = ServiceProvider.GetService<SalesOrderPaymentObject>();
            AddChildObject(Payment, objPayment);
            DataObject objSales = ServiceProvider.GetService<SalesOrderSalesObject>();
            AddChildObject(Sales, objSales);
        }

        #endregion

        #region CRUD Operations

        protected override async Task<ErrorList> DoReadAsync(object options, CancellationToken token = default)
        {
            var output = await SalesOrder_ReadAsync(options);
            return output.Messages;
        }

        protected override async Task<ErrorList> DoSaveAsync(object options, CancellationToken token = default)
        {
            if (IsNew)
            {
                var output = await SalesOrder_CreateAsync(options);
                return output.Messages;
            }
            else
            {
                var output = await SalesOrder_UpdateAsync(options);
                return output.Messages;
            }
        }

        protected override async Task<ErrorList> DoDeleteAsync(object options, CancellationToken token = default)
        {
            var output = await SalesOrder_DeleteAsync(options);
            return output.Messages;
        }

        #endregion

        #region Service Operations

        protected virtual async Task<Output<SalesOrder_ReadOutput>> SalesOrder_ReadAsync(object options)
        {
            int _salesOrderId = (int)SalesOrderIdProperty.TransportValue;
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().ReadAsync(_salesOrderId);

                await FromDataContractAsync(output?.Result, options);
                return output;
            }
        }

        protected virtual async Task<Output<SalesOrder_CreateOutput>> SalesOrder_CreateAsync(object options)
        {
            SalesOrder_CreateInput _data = ToDataContract<SalesOrder_CreateInput>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().CreateAsync(_data);

                await FromDataContractAsync(output?.Result, options);
                return output;
            }
        }

        protected virtual async Task<Output<SalesOrder_UpdateOutput>> SalesOrder_UpdateAsync(object options)
        {
            int _salesOrderId = (int)SalesOrderIdProperty.TransportValue;
            SalesOrder_UpdateInput_Data _data = ToDataContract<SalesOrder_UpdateInput_Data>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().UpdateAsync(_salesOrderId, _data);

                await FromDataContractAsync(output?.Result, options);
                return output;
            }
        }

        protected virtual async Task<Output> SalesOrder_DeleteAsync(object options)
        {
            int _salesOrderId = (int)SalesOrderIdProperty.TransportValue;
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().DeleteAsync(_salesOrderId);

                return output;
            }
        }

        #endregion
    }
}