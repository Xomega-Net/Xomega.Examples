import { ErrorSeverity, ErrorMessage } from 'xomega'

class MessageListWidget {

    public settings: any;

    public activate(settings) {
        this.settings = settings;
    }

    public title(): string {
        var errors = this.settings.items() as Array<ErrorMessage>;
        var str = errors.some((err) => { return err.Severity > ErrorSeverity.Warning }) ? 'error' :
            errors.some((err) => { return err.Severity > ErrorSeverity.Info }) ? 'warning' : 'message';
        str = 'Please review the following ' + str;
        if (errors.length > 1) str += 's';
        return str;
    }

    public iconClass(severity): string {
        switch (severity) {
            case ErrorSeverity.Critical:
            case ErrorSeverity.Error: return 'fa-exclamation-circle';
            case ErrorSeverity.Warning: return 'fa-exclamation-triangle';
            case ErrorSeverity.Info: return 'fa-info-circle';
        }
        return '';
    }

    public close() {
        this.settings.items.removeAll();
    }
}

export = MessageListWidget;
