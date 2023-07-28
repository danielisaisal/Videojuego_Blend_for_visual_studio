using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playback;
using Windows.Media.Core;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _212_TDBNP_3P_EX_DISR
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Juego : Page
    {
        List<imagen> lstimg = new List<imagen>();
        List<imagen> Escenario = new List<imagen>();
        MediaPlayer player = new MediaPlayer();
        DispatcherTimer timerCompu;
        DispatcherTimer timerCompu2;
        int cont = 0, contEs = 0;
        int contT = 50, contT2 = 6;
        public Juego()
        {
            this.InitializeComponent();
            lstimg.Add(new imagen("ms-appx:///Assets/molly2.png"));
            lstimg.Add(new imagen("ms-appx:///Assets/molli_gif.gif"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia1.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia2.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia3.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia4.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia5.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia6.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia7.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia8.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia9.png"));
            Escenario.Add(new imagen("ms-appx:///Assets/secuencia_ecenarios/secuencia10.png"));
            Cancion();

            timerCompu = new DispatcherTimer();
            timerCompu.Interval = new TimeSpan(0,0,1);
            timerCompu.Tick += dispatcherTimer_Tick;
            timerCompu.Start();

            btnEscapar.IsEnabled = false;
        }

        

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Right)
            {
                cont = 1;
                this.imgSprite.Source = new BitmapImage(new Uri(lstimg[cont].image));
                contEs += 1;
                this.imgEscenario1.Source = new BitmapImage(new Uri(Escenario[contEs].image));
                this.imgEscenario2.Source = new BitmapImage(new Uri(Escenario[contEs+1].image));
                //if (contEs == 3 || contEs == 5 || contEs == 7 || contEs == 9)
                //{
                //player.Pause();
                //}
                //if (contEs == 4 || contEs == 6 || contEs == 10 || contEs == 10)
                //{
                //Cancion();
                //}
                this.sldBatteri.Value = contEs;
                if (contEs == 8)
                {
                    btnEscapar.Opacity = 100;
                    btnEscapar.IsEnabled = true;
                }
            }
        }

        private void tsLinterna_Toggled(object sender, RoutedEventArgs e)
        {
            timerCompu2 = new DispatcherTimer();
            timerCompu2.Interval = new TimeSpan(0, 0, 1);
            timerCompu2.Tick += dispatcherTimer2_Tick;
            timerCompu2.Start();

            if (contEs == 4 || contEs == 6 || contEs == 10 && tsLinterna.IsOn == false)
            {
                timerCompu.Stop();
                timerCompu2.Stop();
                this.Frame.Navigate(typeof(GameOver));
                player.Pause();
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (contEs == 3 || contEs == 5 || contEs == 8 )
            {
                sbFantasma.Begin();
            }
            else if (contEs == 0 || contEs == 1 || contEs == 2 || contEs == 4 || contEs == 6 || contEs == 7 || contEs == 8)
            {
                sbRectangulo.Begin();
            }
        }

        private void btnEscapar_Click(object sender, RoutedEventArgs e)
        {
            timerCompu.Stop();
            timerCompu2.Stop();
            this.Frame.Navigate(typeof(Ganaste));
            player.Pause();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            contT -= 1;
            this.txtTemporizador.Text = contT.ToString();
            if (contT == 0)
            {
                timerCompu.Stop();
                timerCompu2.Stop();
                this.Frame.Navigate(typeof(GameOver));
                player.Pause();
            }
        }

        void dispatcherTimer2_Tick(object sender, object e)
        {
            contT2 -= 1;
            this.txtDuracion.Text = contT2.ToString();
            if (contT2 < 4 && contT2 > 0)
            {
                tsLinterna.IsOn = false;
            }
            else if (contT2 == 0)
            {
                timerCompu2.Stop();
                tsLinterna.IsOn = true;
            }
        }

        public async void Cancion()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("WaterfallUndertale.mp3");
            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }

        #region sin utilizar
        private void ToggleSwitch_KeyDown(object sender, KeyRoutedEventArgs e)
        {
        }

        private void Image_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }
        #endregion
    }
}
