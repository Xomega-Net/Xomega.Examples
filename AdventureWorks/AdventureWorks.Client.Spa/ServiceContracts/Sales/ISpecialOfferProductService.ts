//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "TS Service Contracts" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

import * as $ from 'jquery';
import { AuthManager } from 'xomega';

export class ISpecialOfferProductService {

    public static getReadListAsyncRequest(_productId: any): JQueryAjaxSettings {
        let req: JQueryAjaxSettings = AuthManager.Current.createAjaxRequest();
        req.type = 'GET';
        req.url += `product/${ _productId }/special offer`;
        return req;
    }
}

export class SpecialOfferProduct_ReadListOutput {
    public SpecialOfferId: any = null;
    public Description: any = null;
    public Discount: any = null;
    public MinQty: any = null;
    public MaxQty: any = null;
    public Active: any = null;
}