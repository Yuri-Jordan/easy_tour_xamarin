using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Plugin.Media;

namespace EasyTourYuriHugo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarLugar : ContentPage
    {
        String caminhoFotoGlobal = "";
        String latitudeFoto = "";
        String longitudeFoto = "";

        bool camposPreenchidos = false;
        bool fotoCadastrada = false;

        public CriarLugar()
        {
            InitializeComponent();
        }

        async void buscarLocalicacao(object sender, EventArgs e)
        {
            var gps = CrossGeolocator.Current;
            gps.DesiredAccuracy = 50;

            var localizacao = await gps.GetPositionAsync();

            latitude.Text = latitudeFoto = localizacao.Latitude.ToString();
            longitude.Text = longitudeFoto = localizacao.Longitude.ToString();
        }

        async void tirarFoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Câmera indisponível.", "Câmera indisponível.", "OK");
                return;
            }

            var arquivo = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "easytour",
                    //Name = "teste"
                });

            if(arquivo == null)
            {
                await DisplayAlert("Foto não salva", ":(", "OK");
                return;
            }

            caminhoFoto.Text = caminhoFotoGlobal = arquivo.Path;

            foto.Source = ImageSource.FromStream(() =>
            {
                var stream = arquivo.GetStream();
                arquivo.Dispose();
                return stream;
            });
        }

        async void salvarFotoBanco(object sender, EventArgs e)
        {
            var titulo = "";
            try
            {
                titulo = titulo_entry.Text.Trim();

                if (titulo != "")
                    camposPreenchidos = true;
                else
                    await DisplayAlert("Campo vazio!", "Dê um título a foto.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Campo vazio!", "Dê um título a foto.", "OK");
            }

            if (camposPreenchidos)
            {
                try
                {
                    camposPreenchidos = false;
                    await App.conexaoBancoFoto.salvarFoto(new Models.Foto(titulo, caminhoFotoGlobal.Trim(), latitudeFoto, longitudeFoto));
                    fotoCadastrada = true;
                }
                catch (Exception)
                {
                    await DisplayAlert(titulo, "Já existe.", "OK");
                }
            }

            if (fotoCadastrada)
            {

                try
                {
                    fotoCadastrada = false;
                    var retornado = await App.conexaoBancoFoto.buscarFoto(titulo);

                    await DisplayAlert(
                        retornado.titulo + "\n"
                        + retornado.latitude + "\n"
                        + retornado.longitude + "\n"
                        + retornado.caminho, "Foto salva", "OK");


                }
                catch (Exception)
                {
                    await DisplayAlert(titulo, "Foto não encontrada.", "OK");
                }
                
            }
            
        }
    }
}