using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Wpf
{
    /// <summary>
    /// Interaction logic for Errors.xaml
    /// </summary>
    public partial class Errors : UserControl, IErrorPresenter
    {
        private ErrorList errorList;

        public Errors()
        {
            InitializeComponent();
            Visibility = Visibility.Collapsed;
        }

        void IErrorPresenter.Show(ErrorList errorList)
        {
            Dispatcher.Invoke(() => ShowErrors(errorList));
        }

        private void ShowErrors(ErrorList errorList)
        {
            this.errorList = errorList;
            if (errorList == null || errorList.Errors.Count == 0)
            {
                Visibility = Visibility.Collapsed;
                lstErrors.ItemsSource = null;
                title.Text = "";
            }
            else
            {
                lstErrors.ItemsSource = errorList.Errors;
                Visibility = Visibility.Visible;
                string str = errorList.Errors.Any(e => e.Severity > ErrorSeverity.Warning) ? "error" :
                    errorList.Errors.Any(e => e.Severity > ErrorSeverity.Info) ? "warning" : "message";
                str = "Please review the following " + str;
                if (errorList.Errors.Count > 1) str += "s";
                title.Text = str;
            }
        }

        public void HideClose()
        {
            btnClose.Visibility = Visibility.Hidden;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (errorList != null) errorList.Clear();
            ((IErrorPresenter)this).Show(errorList);
        }
    }
}
