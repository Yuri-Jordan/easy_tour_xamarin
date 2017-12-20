using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EasyTourYuriHugo.Models;
using System.Collections.ObjectModel;

namespace EasyTourYuriHugo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuariosEmBanco : ContentPage
    {
        ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
        public UsuariosEmBanco()
        {
            InitializeComponent();

            listaUsuarios.ItemsSource = usuarios;
            popularLista(usuarios);
        }

        private async void popularLista(ObservableCollection<Usuario> usuarios)
        {
            List<Usuario> usuariosDoBanco = await App.conexaoBancoUsuario.buscarUsuarios();

            foreach (Usuario usu in usuariosDoBanco)
            {
                System.Diagnostics.Debug.WriteLine("LISTA : Usuário - " + usu.nome + " | Senha - " + usu.senha);
                usuarios.Add(new Usuario(usu.nome, usu.senha));
            }
        }
    }
}