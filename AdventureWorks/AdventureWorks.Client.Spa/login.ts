import router = require("plugins/router");
import jwtDecode = require('jwt_decode');
import { AuthManager, ViewModel } from 'xomega';
import LoginViewCustomized = require("Views/Person/LoginViewCustomized");

class Login extends LoginViewCustomized {

    public onSave() {
        this.obj.validate(true);
        if (this.obj.ValidationErrors.hasErrors()) return;

        let req = this.getLoginRequest();
        let credentials = {
            username: this.obj.Email.EditStringValue(),
            password: this.obj.Password.EditStringValue()
        };
        req.data = JSON.stringify(credentials);
        req.error = (jqXHR, textStatus, errorThrow) => {
            this.obj.ValidationErrors.mergeWith(xomega.ErrorList.fromErrorResponse(jqXHR, errorThrow));
        };

        $.ajax(req);
    }

    private getLoginRequest(): JQueryAjaxSettings {
        let req: JQueryAjaxSettings = AuthManager.Current.createAjaxRequest();
        req.type = 'POST';
        req.url += 'authentication';
        let vm = this;
        req.success = function (data, textStatus, jqXHR) {
            var jwtToken = jqXHR.responseJSON.Result;
            AuthManager.Current.signIn(jwtToken, jwtDecode(jwtToken));
            router.navigate('#' + vm.Params[xomega.AuthManager.ReturnParam]);
        };
        return req;
    }
}
export = Login;
