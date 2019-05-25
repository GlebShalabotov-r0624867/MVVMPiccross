using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MediaPlayer player;
        public string pad;
        protected override void OnStartup(StartupEventArgs e)
        {

            pad = "../Africa.wav";

            base.OnStartup(e);

            var main = new MainWindow();
            Navigator nav = new Navigator();
            main.DataContext = nav;

            main.Show();
            //PlayableWindow pw = new PlayableWindow();
            //main.DataContext = pw;
            //pw.ClosingAction += MainViewModel_ApplicationExit;
            player = new MediaPlayer();
            player.Volume = 0.2;
            player.MediaEnded += OnMediaEnded;
            player.Open(new Uri(pad, UriKind.Relative));
            player.Play();

        }

        private void OnMediaEnded(object sender, EventArgs e)
        {
            player.Open(new Uri(pad, UriKind.Relative));
            player.Play();
        }

        
    }
}
