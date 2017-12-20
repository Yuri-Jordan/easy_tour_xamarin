using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace EasyTourYuriHugo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusLugares : ContentPage
    {
        public MeusLugares()
        {
            InitializeComponent();
            //iniciarMapa();
        }

        private void iniciarMapa()
        {
            var mapa = new Map(MapSpan.FromCenterAndRadius(
                new Position(454, 4654),
                Distance.FromMiles(0.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //var stack = new StackLayout { Spacing = 0 };
            //stack.Children.Add(mapa);
            //Content = stack;

            pingarNoMapa();
        }

        private void pingarNoMapa()
        {
            var localizacao1 = new Position(123.0, 321.0);
            var localizacao2 = new Position(123.4, 321.4);
            var localizacao3 = new Position(123.1, 321.1);
            var localizacao4 = new Position(123.2, 321.2);
            var localizacao5 = new Position(123.5, 321.05);

            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = localizacao1,
                Label = "pin1"
            };

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = localizacao2,
                Label = "pin2"
            };

            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = localizacao3,
                Label = "pin3"
            };

            var pin4 = new Pin
            {
                Type = PinType.Place,
                Position = localizacao4,
                Label = "pin4"
            };

            var pin5 = new Pin
            {
                Type = PinType.Place,
                Position = localizacao5,
                Label = "pin5"
            };
        }
    }
}