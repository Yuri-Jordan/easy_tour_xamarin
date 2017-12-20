using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using EasyTourYuriHugo.Models;
using System.Collections.ObjectModel;
using Android.Graphics;
using System.Windows.Input;

namespace EasyTourYuriHugo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusLugares : ContentPage
    {
        ObservableCollection<MeuLugar> lugares = new ObservableCollection<MeuLugar>();

        public MeusLugares()
        {
            InitializeComponent();
            //iniciarMapa();
            inicializarLista();
        }

        async Task inicializarLista()
        {
            lista.ItemsSource = lugares;
            await popularLista(lugares);
        }

        private async Task popularLista(ObservableCollection<MeuLugar> lugares)
        {
            lugares.Clear();
            List<MeuLugar> lugaresDoBanco = await App.conexaoBancoMeuLugar.buscarMeusLugares();
            lugaresDoBanco.Reverse();

            foreach (MeuLugar ml in lugaresDoBanco)
            {
                System.Diagnostics.Debug.WriteLine("LISTA :" + ml.titulo);

                var meuLugar = new MeuLugar(ml.titulo, ml.caminho, ml.latitude, ml.longitude);
                meuLugar.fotoLocal = ImageSource.FromFile(ml.caminho.Trim());

                lugares.Add(meuLugar);
                lista.IsRefreshing = false;
            }
        }

        public void atualizarLista(object sender, EventArgs e)
        {
            inicializarLista();
        }

        //private void iniciarMapa()
        //{
        //    var map = new Map(
        //    MapSpan.FromCenterAndRadius(
        //            new Position(37, -122), Distance.FromMiles(0.3)))
        //    {
        //        IsShowingUser = true,
        //        HeightRequest = 100,
        //        WidthRequest = 960,
        //        VerticalOptions = LayoutOptions.FillAndExpand
        //    };
        //    var stack = new StackLayout { Spacing = 0 };
        //    stack.Children.Add(map);
        //    Content = stack;
        //}

        //private void pingarNoMapa()
        //{
        //    var localizacao1 = new Position(123.0, 321.0);
        //    var localizacao2 = new Position(123.4, 321.4);
        //    var localizacao3 = new Position(123.1, 321.1);
        //    var localizacao4 = new Position(123.2, 321.2);
        //    var localizacao5 = new Position(123.5, 321.05);

        //    var pin1 = new Pin
        //    {
        //        Type = PinType.Place,
        //        Position = localizacao1,
        //        Label = "pin1"
        //    };

        //    var pin2 = new Pin
        //    {
        //        Type = PinType.Place,
        //        Position = localizacao2,
        //        Label = "pin2"
        //    };

        //    var pin3 = new Pin
        //    {
        //        Type = PinType.Place,
        //        Position = localizacao3,
        //        Label = "pin3"
        //    };

        //    var pin4 = new Pin
        //    {
        //        Type = PinType.Place,
        //        Position = localizacao4,
        //        Label = "pin4"
        //    };

        //    var pin5 = new Pin
        //    {
        //        Type = PinType.Place,
        //        Position = localizacao5,
        //        Label = "pin5"
        //    };
        //}
    }
}