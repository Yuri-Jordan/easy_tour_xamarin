using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EasyTourYuriHugo.BD;
using EasyTourYuriHugo.Models;

namespace EasyTourYuriHugo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaLogin : ContentPage
	{
    
		public PaginaLogin ()
		{
			InitializeComponent ();
		}


        async void logar(object sender, EventArgs e)
        {
            var usuario = "";
            var senha = "";
            var usuarioCadastrado = false;
            var usuarioRetornado = new Usuario();
            var camposPreenchidos = false;

            try
            {
                usuario = ntr_usuario.Text.Trim();
                senha = ntr_senha.Text.Trim();
                if (usuario != "" && senha != "")
                    camposPreenchidos = true;
                else
                    DisplayAlert("Campo vazio!", "Preencha os campos corretamente.", "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Campo vazio!", "Preencha os campos corretamente.", "OK");
            }

            if (camposPreenchidos)
            {
                try
                {
                    usuarioRetornado = await App.conexaoBancoUsuario.buscarUsuario(usuario);
                    usuarioCadastrado = true;
                }
                catch (Exception)
                {
                    DisplayAlert(usuario, "Usuário inexistente.", "OK");
                }
            }

            if (usuarioCadastrado)
            {
                if (usuarioRetornado.nome.Equals(usuario) && usuarioRetornado.senha.Equals(senha))
                {
                    DisplayAlert(usuario, "Logando...", "OK");
                    Navigation.PushAsync( new MainPage());
                }
                else
                {
                    DisplayAlert(usuario, "Senha errada.", "OK");
                }
            }

        }      


        void criarConta(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaCadastro());

        }
	}
}