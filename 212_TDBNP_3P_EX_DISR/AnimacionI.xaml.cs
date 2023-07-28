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
using Windows.Media.Playback;
using Windows.Media.Core;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _212_TDBNP_3P_EX_DISR
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AnimacionI : Page
    {
        MediaPlayer player = new MediaPlayer();
        public AnimacionI()
        {
            this.InitializeComponent();
            rt2.Visibility = Visibility.Collapsed;
            txtInstrucciones.Visibility = Visibility.Collapsed;
            txtTituloIntrucciones.Visibility = Visibility.Collapsed;
            imgHistoria.Visibility = Visibility.Collapsed;
            rtTapado.Visibility = Visibility.Collapsed;
            txtHistoria2.Visibility = Visibility.Collapsed;
            btnSiguiente2.IsEnabled = false;
            btnSiguiente3.IsEnabled = false;

            Cancion();
        }

        private void btnSiguiente1_Click(object sender, RoutedEventArgs e)
        {
            rt1.Visibility = Visibility.Collapsed;
            txtDescripcionC.Visibility = Visibility.Collapsed;
            txtTituloC.Visibility = Visibility.Collapsed;
            btnSiguiente1.Visibility = Visibility.Collapsed;
            btnSiguiente1.IsEnabled = false;
            imgHistoria.Visibility = Visibility.Visible;
            rtTapado.Visibility = Visibility.Visible;
            txtHistoria2.Visibility = Visibility.Visible;
            btnSiguiente2.IsEnabled = true;
        }

        private void btnSiguiente2_Click(object sender, RoutedEventArgs e)
        {
            imgHistoria.Visibility = Visibility.Collapsed;
            rtTapado.Visibility = Visibility.Collapsed;
            txtHistoria2.Visibility = Visibility.Collapsed;
            btnSiguiente2.IsEnabled = false;
            btnSiguiente2.Visibility = Visibility.Collapsed;
            btnSiguiente3.IsEnabled = true;
            rt2.Visibility = Visibility.Visible;
            txtInstrucciones.Visibility = Visibility.Visible;
            txtTituloIntrucciones.Visibility = Visibility.Visible;
            
        }

        public async void Cancion()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("Candies.mp3");

            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }

        private void btnSiguiente3_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            this.Frame.Navigate(typeof(Juego));
        }
    }
}
