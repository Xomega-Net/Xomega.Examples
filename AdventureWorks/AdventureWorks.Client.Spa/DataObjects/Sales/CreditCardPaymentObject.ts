//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "XomegaJS Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

import { DataObject, TextProperty, EnumProperty } from 'xomega';

export class CreditCardPaymentObject extends DataObject {

    // Properties
    public CardNumber: TextProperty;
    public CreditCardApprovalCode: TextProperty;
    public CreditCardId: EnumProperty;
    public Expiration: TextProperty;

    // Construction and initialization
    init() {
        this.CardNumber = new TextProperty();
        this.CardNumber.Required(true);
        this.CardNumber.Size = 25;
        this.CardNumber.Editable(false);
        this.CreditCardApprovalCode = new TextProperty();
        this.CreditCardApprovalCode.Size = 15;
        this.CreditCardId = new EnumProperty();
        this.CreditCardId.Required(true);
        this.Expiration = new TextProperty();
        this.Expiration.Editable(false);
    }
}
