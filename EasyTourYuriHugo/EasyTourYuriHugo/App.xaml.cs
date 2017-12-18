using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyTourYuriHugo.BD;

using Xamarin.Forms;

namespace EasyTourYuriHugo
{
    public partial class App : Application
    {
        static UsuarioDAO banco;
        public static UsuarioDAO conexaoBancoUsuario
        {
            get
            {
                if (banco == null)
                    banco = new UsuarioDAO(DependencyService.Get<IFileHelper>().GetLocalFilePath("usuarios.sqlite"));

                return banco;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EasyTourYuriHugo.Views.PaginaLogin());
            //MainPage = new NavigationPage(new EasyTourYuriHugo.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
