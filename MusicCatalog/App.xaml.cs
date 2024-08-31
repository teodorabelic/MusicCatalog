using MusicCatalog.View;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MusicCatalog
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            HomePageUnregisteredWindow homePage = new HomePageUnregisteredWindow();
            homePage.Show();
        }
    }
}
