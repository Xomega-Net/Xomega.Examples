using System.Windows;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Wpf
{
    /// <summary>
    /// Interaction logic for ErrorsView.xaml
    /// </summary>
    public partial class ErrorsView : Window, IErrorPresenter
    {
        public ErrorsView()
        {
            InitializeComponent();
            errorsControl.HideClose();
        }

        public void Show(ErrorList errors)
        {
            IErrorPresenter ep = errorsControl;
            ep.Show(errors);
            Show();
        }
    }
}