using EasyTourYuriHugo.Models;
using EasyTourYuriHugo.Services;
using EasyTourYuriHugo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTourYuriHugo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public  partial class Roteiros : ContentPage
    {

        public Roteiros()
        {
            InitializeComponent();
            categoriasRoteiroListView.ItemsSource = r(); 

        }

        private List<CategoriaRoteiro> r()
        {
           return new CategoriasRoteiroVM().listaCatRoteiros;
        }

    }
}