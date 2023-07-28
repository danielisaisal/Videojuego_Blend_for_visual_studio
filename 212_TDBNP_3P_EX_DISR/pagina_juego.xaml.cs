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
using Windows.UI.Xaml.Media.Imaging;
using Windows.Media.Playback;
using Windows.Media.Core;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _212_TDBNP_3P_EX_DISR
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class pagina_juego : Page
    {
        List<Menu> lstimgs = new List<Menu>();
        MediaPlayer player = new MediaPlayer();
        int cont = 0;
        
        public pagina_juego()
        {
            this.InitializeComponent();
            sbInicioP.Begin();
            Cancion();

            lstimgs.Add(new Menu("ms-appx:///Assets/castle_ghost.gif" , "Castle Ghost"));
            lstimgs.Add(new Menu( "ms-appx:///Assets/Spooky_Dance.gif", "Spooky Dance"));

            foreach (Menu x in lstimgs)
            {
                this.cmbImagen.Items.Add(x.describ);
            }
        }

        public async void Cancion() {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("Luig.mp3");

            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            this.Frame.Navigate(typeof(AnimacionI));
        }

        private void cmbImagen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cont = this.cmbImagen.SelectedIndex;
            this.image.Source = new BitmapImage(new Uri(lstimgs[cont].image));
        }

        private void btnScreamer_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            this.Frame.Navigate(typeof(Screamer));
        }
    }
}
