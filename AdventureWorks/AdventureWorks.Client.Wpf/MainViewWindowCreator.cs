using System.Windows;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Wpf
{
    // This class allows Xomega Framework to create custom windows
    // based on the MainView - using the same menu, status bar, etc.
    public class MainViewWindowCreator : IWindowCreator
    {
        public Window CreateWindow(WPFView view)
        {
            if (view is LoginView)
                return new Window { Content = view };

            MainView mv = new MainView();
            mv.body.Content = view;
            return mv;
        }
    }
}
