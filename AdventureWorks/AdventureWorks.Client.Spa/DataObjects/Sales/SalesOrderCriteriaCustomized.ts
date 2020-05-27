
import { SalesOrderCriteria as GeneratedDataObject } from 'DataObjects/Sales/SalesOrderCriteria';
import { Header, AuthManager, AccessLevel } from 'xomega';
import { SalesPerson, PersonType, SalesTerritory } from '../../Enumerations/Enumerations';

export class SalesOrderCriteria extends GeneratedDataObject {

    init() {
        super.init();
    }

    onInitialized() {
        super.onInitialized();
        this.Status.DisplayFormat = `${Header.fieldId} - ${Header.fieldText}`;

        this.TerritoryId.setCascadingProperty(SalesTerritory.Attributes.Group, this.GlobalRegion);

        this.SalesPersonId.setCascadingProperty(SalesPerson.Attributes.TerritoryId, this.TerritoryId);
        this.SalesPersonId.DisplayListSeparator = '; ';
        this.SalesPersonId.nullsMatchAnyCascading = true;

        let claims = AuthManager.Current.Claims;
        if (claims && (claims.role == PersonType.StoreContact
            || claims.role == PersonType.IndividualCustomer)) {
            this.CustomerStoreOperator.AccessLevel(AccessLevel.None);
            this.CustomerNameOperator.AccessLevel(AccessLevel.None);
        }
    }

    public validate(force: boolean) {
        super.validate(force);
        if (!this.OrderDate.isNull() && !this.OrderDate2.isNull() &&
            this.OrderDate.InternalValue() > this.OrderDate2.InternalValue())
            this.ValidationErrors.addError('From Order Date should be earlier than To Order Date');
    }

}