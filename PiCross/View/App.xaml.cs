using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var main = new MainWindow();
            Navigator nav = new Navigator();
            main.DataContext = nav;
            //PlayableWindow pw = new PlayableWindow();
            //main.DataContext = pw;
            //pw.ClosingAction += MainViewModel_ApplicationExit;
            main.Show();
        }

        private void MainViewModel_ApplicationExit()
        {
            Application.Current.Shutdown();
        }
    }
}
