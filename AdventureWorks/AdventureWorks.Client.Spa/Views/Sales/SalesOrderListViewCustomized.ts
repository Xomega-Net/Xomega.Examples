
import GeneratedViewModel = require('Views/Sales/SalesOrderListView');

class SalesOrderListViewCustomized extends GeneratedViewModel {

    public getView() {
        // change this method to specify a custom view, can return a path to view or DOM element
        return 'Views/Sales/SalesOrderListView.html';
    }
    // add custom code here
}

export = SalesOrderListViewCustomized;
