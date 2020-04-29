
import { AuthenticationObject as GeneratedDataObject } from 'DataObjects/Person/AuthenticationObject';

export class AuthenticationObject extends GeneratedDataObject {

    // construct properties and child objects
    init() {
        super.init();
        // add custom construction code here
    }

    // perform post intialization
    onInitialized() {
        super.onInitialized();
        this.Email.InternalValue('jay1@adventure-works.com');
        this.Password.InternalValue('password');
        this.TrackModifications = false;
    }

    // add custom code here

}