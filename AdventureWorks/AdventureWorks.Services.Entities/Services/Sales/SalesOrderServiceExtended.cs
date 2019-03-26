using System;
using System.Linq;

namespace AdventureWorks.Services.Entities
{
    public partial class SalesOrderService
    {

        protected PaymentInfo GetPaymentInfo(SalesOrder obj)
        {
            PaymentInfo res = new PaymentInfo()
            {
                CreditCard = new PaymentInfo_CreditCard
                {
                    CreditCardId = obj.CreditCardObject?.CreditCardId ?? 0,
                    CreditCardApprovalCode = obj.CreditCardApprovalCode
                },
                DueDate = obj.DueDate,
                SubTotal = obj.SubTotal,
                Freight = obj.Freight,
                TaxAmt = obj.TaxAmt,
                TotalDue = obj.TotalDue,
                ShipMethodId = obj.ShipMethodObject?.ShipMethodId ?? 0,
                CurrencyRate = obj.CurrencyRateObject?.RateString
            };
            return res;
        }

        protected void UpdatePayment(SalesOrder obj, PaymentUpdate _data)
        {
            if (_data == null)
            {
                currentErrors.AddValidationError(Messages.PaymentRequired, obj.SalesOrderId);
                return;
            }
            obj.DueDate = _data.DueDate;
            obj.ShipMethodObject = ctx.FindEntity<ShipMethod>(currentErrors, _data.ShipMethodId);
            if (_data.CreditCard != null)
            {
                obj.CreditCardApprovalCode = _data.CreditCard.CreditCardApprovalCode;
                obj.CreditCardObject = ctx.FindEntity<CreditCard>(currentErrors, _data.CreditCard.CreditCardId);
            }
        }

        protected SalesInfo GetSalesInfo(SalesOrder obj)
        {
            SalesInfo res = new SalesInfo()
            {
                SalesPersonId = obj.SalesPersonObject?.BusinessEntityId,
                TerritoryId = obj.TerritoryObject?.TerritoryId,
                // select a list of sales reason IDs from the child list
                SalesReason = obj.ReasonObjectList?.Select(r => r.SalesReasonId).ToList()
            };
            return res;
        }

        protected void UpdateSalesInfo(SalesOrder obj, SalesInfo _data)
        {
            if (_data == null)
            {
                currentErrors.AddValidationError(Messages.SalesRequired, obj.SalesOrderId);
                return;
            }
            obj.TerritoryObject = ctx.FindEntity<SalesTerritory>(currentErrors, _data.TerritoryId);
            obj.SalesPersonObject = ctx.Find<SalesPerson>(currentErrors, _data.SalesPersonId);
            // remove sales reason that are not in the provided list
            obj.ReasonObjectList.Where(r => _data.SalesReason == null || !_data.SalesReason.Contains(r.SalesReasonId))
                .ToList().ForEach(r => obj.ReasonObjectList.Remove(r));
            if (_data.SalesReason != null)
            {
                // add sales reasons from provided list that don't exist yet
                _data.SalesReason.Where(rId => obj.ReasonObjectList.Where(r => r.SalesReasonId == rId).ToList().Count == 0)
                    .ToList().ForEach(rId => obj.ReasonObjectList.Add(new SalesOrderReason()
                    {
                        SalesOrderId = obj.SalesOrderId,
                        SalesReasonId = rId,
                        ModifiedDate = DateTime.Now
                    }));
            }
        }
        protected CustomerInfo GetCustomerInfo(SalesOrder obj)
        {
            CustomerInfo res = new CustomerInfo();
            if (obj.CustomerObject != null)
            {
                res.CustomerId = obj.CustomerObject.CustomerId;
                res.AccountNumber = obj.CustomerObject.AccountNumber;
                res.PersonId = obj.CustomerObject.PersonObject?.BusinessEntityId;
                res.PersonName = obj.CustomerObject.PersonObject?.FullName;
                res.StoreId = obj.CustomerObject.StoreObject?.BusinessEntityId;
                res.StoreName = obj.CustomerObject.StoreObject?.Name;
                res.TerritoryId = obj.CustomerObject.TerritoryObject?.TerritoryId;
            };
            if (obj.BillToAddressObject != null)
                res.BillingAddress = new AddressKey { AddressId = obj.BillToAddressObject.AddressId };
            if (obj.ShipToAddressObject != null)
                res.ShippingAddress = new AddressKey { AddressId = obj.ShipToAddressObject.AddressId };
            return res;
        }

        protected void UpdateCustomer(SalesOrder obj, CustomerUpdate _data)
        {
            if (_data == null)
            {
                currentErrors.AddValidationError(Messages.CustomerRequired, obj.SalesOrderId);
                return;
            }
            obj.CustomerObject = ctx.FindEntity<Customer>(currentErrors, _data.CustomerId);
            obj.BillToAddressObject = ctx.FindEntity<Address>(currentErrors, _data.BillingAddress?.AddressId);
            obj.ShipToAddressObject = ctx.FindEntity<Address>(currentErrors, _data.ShippingAddress?.AddressId);
        }
    }
}