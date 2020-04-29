using AdventureWorks.Client.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(cfg =>
                {
                    cfg.SetBasePath(Directory.GetCurrentDirectory());
#if TWO_TIER
                    cfg.AddXmlFile("db.config", optional: false, reloadOnChange: false);
#endif
                })
                .ConfigureServices((ctx, services) => WpfAppInit.ConfigureServices(ctx, services))
                .Build();
        }

        public static IServiceProvider Services => ((App)Current).host.Services;

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            base.OnStartup(e);

            await ViewModel.NavigateToAsync(
                Services.GetService<LoginViewModel>(),
                Services.GetService<LoginView>(),
                new NameValueCollection { { ViewParams.Mode.Param, ViewParams.Mode.Popup } },
                null, null);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }
            base.OnExit(e);
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ErrorParser errorParser = Services.GetService<ErrorParser>();
            IErrorPresenter errorPresenter = Services.GetService<IErrorPresenter>();
            if (errorPresenter != null && errorParser != null)
            {
                e.Handled = true;
                errorPresenter.Show(errorParser.FromException(e.Exception));
            }
        }
    }
}
