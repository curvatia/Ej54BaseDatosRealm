using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ej54BaseDatosRealm
{
    public partial class App : Application
    {
        public object Navigation { get; }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Views.Inicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
