using EasyTourYuriHugo.Models;
using EasyTourYuriHugo.Services;
using EasyTourYuriHugo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyTourYuriHugo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Roteiros : ContentPage
    {
        ObservableCollection<CategoriaRoteiro> roteiros = new ObservableCollection<CategoriaRoteiro>();
        public Roteiros()
        {
            InitializeComponent();

            lista.ItemsSource = roteiros;
            popularLista(roteiros);
        }

        private async void popularLista(ObservableCollection<CategoriaRoteiro> roteiros)
        {
            List<CategoriaRoteiro> roteirosDoServico = await new ViewModels.CategoriasRoteiroVM().buscarRoteiros();

            foreach (CategoriaRoteiro cr in roteirosDoServico)
            {
                System.Diagnostics.Debug.WriteLine("LISTA :" + cr.nome);
                roteiros.Add(new CategoriaRoteiro(cr.id, cr.nome, cr.criadaEm));
            }
        }
    }
}