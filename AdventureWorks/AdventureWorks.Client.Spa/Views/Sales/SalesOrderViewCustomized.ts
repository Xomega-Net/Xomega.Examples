
import GeneratedViewModel = require('Views/Sales/SalesOrderView');

class SalesOrderViewCustomized extends GeneratedViewModel {

    public getView() {
        // change this method to specify a custom view, can return a path to view or DOM element
        return 'Views/Sales/SalesOrderView.html';
    }

    public getViewTitle(): string {
        return super.getViewTitle() + (this.obj.IsNew() ? '' :
            ' - ' + this.obj.SalesOrderNumber.DisplayStringValue());
    }
}

export = SalesOrderViewCustomized;
