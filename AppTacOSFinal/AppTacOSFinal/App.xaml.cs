using Xamarin.Forms;
using AppTacOSFinal.ViewModels.Base;

namespace AppTacOSFinal
{
    public partial class App : Application
    {
        private static FicViewModelLocator ficVmLocator;
        // FIC: Metodo
        public static FicViewModelLocator FicMetLocator
        {
            get { return ficVmLocator = ficVmLocator ?? new FicViewModelLocator(); }
        }
        public App()
        {
            InitializeComponent();

            //MANDAMOS NUESTRO MAESTRO DETALLE COMO MAINPAGE
            //MainPage = new NavigationPage(new Views.CatGenerales.FicViCatEdificiosList(null));
            MainPage = new Views.Navegacion.FicMasterPage();
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

