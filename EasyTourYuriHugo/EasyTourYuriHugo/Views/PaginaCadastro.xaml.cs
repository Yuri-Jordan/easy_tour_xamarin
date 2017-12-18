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
    public partial class PaginaCadastro : ContentPage
    {
        public PaginaCadastro()
        {
            InitializeComponent();
        }

        async void cadastrar(object sender, EventArgs e)
        {
            var usuario = "";
            var senha = "";
            var usuarioCadastrado = false;
            var camposPreenchidos = false;

            try
            {
                usuario = ntr_usuario.Text.Trim();
                senha = ntr_senha.Text.Trim();
                if(usuario != "" && senha != "")
                    camposPreenchidos = true;
                else
                    DisplayAlert("Campo vazio!", "Preencha os campos corretamente.", "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Campo vazio!", "Preencha os campos corretamente.", "OK");
            }

            if(camposPreenchidos)
            {
                try
                {
                    await App.conexaoBancoUsuario.cadastrarUsuario(new Models.Usuario(usuario, senha));
                    usuarioCadastrado = true;
                }
                catch (Exception)
                {
                    DisplayAlert(usuario, "Já existe.", "OK");
                }
            }

            if (usuarioCadastrado)
            {
                var cadastrado = await App.conexaoBancoUsuario.buscarUsuario(usuario);

                if (cadastrado.nome.Equals(usuario))
                {
                    DisplayAlert(usuario, "Cadastrado com sucesso!", "OK");
                    Navigation.PopAsync();
                }
            }


        }
    }
}
