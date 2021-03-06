//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "XomegaJS Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

import { DataObject, EnumIntProperty, TextProperty } from 'xomega';

export class AddressObject extends DataObject {

    // Properties
    public AddressId: EnumIntProperty;
    public AddressLine1: TextProperty;
    public AddressLine2: TextProperty;
    public CityState: TextProperty;
    public Country: TextProperty;
    public PostalCode: TextProperty;

    // Construction and initialization
    init() {
        this.AddressId = new EnumIntProperty();
        this.AddressId.Required(true);
        this.AddressId.IsKey = true;
        this.AddressLine1 = new TextProperty();
        this.AddressLine1.Required(true);
        this.AddressLine1.Size = 60;
        this.AddressLine1.Editable(false);
        this.AddressLine2 = new TextProperty();
        this.AddressLine2.Size = 60;
        this.AddressLine2.Editable(false);
        this.CityState = new TextProperty();
        this.CityState.Editable(false);
        this.Country = new TextProperty();
        this.Country.Size = 3;
        this.Country.Editable(false);
        this.PostalCode = new TextProperty();
        this.PostalCode.Required(true);
        this.PostalCode.Size = 15;
        this.PostalCode.Editable(false);
    }
}
