using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Media.Core;
using Windows.Media.Playback;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _212_TDBNP_3P_EX_DISR
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Screamer : Page
    {
        MediaPlayer player = new MediaPlayer();
        public Screamer()
        {
            this.InitializeComponent();
        }

        private void btnEmpezar_Click(object sender, RoutedEventArgs e)
        {
            Cancion();
        }

        public async void Cancion()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("OOGA BOOG.mp3");
            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
            rtFondo.Visibility = Visibility.Collapsed;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            this.Frame.Navigate(typeof(pagina_juego));
        }
    }
}
