//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Xomega Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;
using Xomega.Framework;
using Xomega.Framework.Properties;

namespace AdventureWorks.Client.Objects
{
    public partial class CreditCardPaymentObject : DataObject
    {
        #region Constants

        public const string CardNumber = "CardNumber";
        public const string CreditCardApprovalCode = "CreditCardApprovalCode";
        public const string CreditCardId = "CreditCardId";
        public const string Expiration = "Expiration";

        #endregion

        #region Properties

        public TextProperty CardNumberProperty { get; private set; }
        public TextProperty CreditCardApprovalCodeProperty { get; private set; }
        public EnumIntProperty CreditCardIdProperty { get; private set; }
        public TextProperty ExpirationProperty { get; private set; }

        #endregion

        #region Construction

        public CreditCardPaymentObject()
        {
        }

        public CreditCardPaymentObject(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Initialize()
        {
            CardNumberProperty = new TextProperty(this, CardNumber);
            CardNumberProperty.Required = true;
            CardNumberProperty.Size = 25;
            CardNumberProperty.Editable = false;
            CreditCardApprovalCodeProperty = new TextProperty(this, CreditCardApprovalCode);
            CreditCardApprovalCodeProperty.Size = 15;
            CreditCardIdProperty = new EnumIntProperty(this, CreditCardId);
            CreditCardIdProperty.Required = true;
            CreditCardIdProperty.Size = 10;
            ExpirationProperty = new TextProperty(this, Expiration);
            ExpirationProperty.Editable = false;
        }

        #endregion
    }
}