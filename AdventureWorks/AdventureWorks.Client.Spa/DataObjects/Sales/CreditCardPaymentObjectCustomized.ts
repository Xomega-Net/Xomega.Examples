
import { CreditCardPaymentObject as GeneratedDataObject } from 'DataObjects/Sales/CreditCardPaymentObject';
import { Header } from 'xomega';
import { PersonCreditCard } from '../../Enumerations/Enumerations';

export class CreditCardPaymentObject extends GeneratedDataObject {

    // construct properties and child objects
    init() {
        super.init();
        // add custom construction code here
    }

    // perform post intialization
    onInitialized() {
        super.onInitialized();
        let obj = this;
        this.CreditCardId.InternalValue.subscribe(function (h: Header) {
            obj.CardNumber.InternalValue(h ? h.attr[PersonCreditCard.Attributes.CardNumber] : null);
            // for composite properties display null if an underlying property is null
            obj.Expiration.InternalValue(h && h.attr[PersonCreditCard.Attributes.ExpYear] ?
                `${h.attr[PersonCreditCard.Attributes.ExpMonth]}/${h.attr[PersonCreditCard.Attributes.ExpYear]}` : null);
        });
    }

    // add custom code here

}