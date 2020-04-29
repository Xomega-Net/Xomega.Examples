
import { SalesOrderObject as GeneratedDataObject } from 'DataObjects/Sales/SalesOrderObject';
import { PersonCreditCardReadListCacheLoader } from '../../CacheLoaders/PersonCreditCardReadListCacheLoader';
import { PersonCreditCard } from '../../Enumerations/Enumerations';

export class SalesOrderObject extends GeneratedDataObject {

    // construct properties and child objects
    init() {
        super.init();
        // add custom construction code here
    }

    // perform post intialization
    onInitialized() {
        super.onInitialized();

        let ccProperty = this.PaymentObject.CreditCardObject.CreditCardId;
        ccProperty.LocalCacheLoader = new PersonCreditCardReadListCacheLoader();
        ccProperty.setCacheLoaderParameters(PersonCreditCard.Parameters.BusinessEntityId, this.CustomerObject.PersonId);
    }

    // add custom code here

}