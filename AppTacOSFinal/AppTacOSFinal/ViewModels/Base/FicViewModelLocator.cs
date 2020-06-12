using Autofac;
using AppTacOSFinal.ViewModels.CedisAlm;
using AppTacOSFinal.Services.Navigation;
using AppTacOSFinal.Interfaces.Navigation;
using AppTacOSFinal.Services.CedisAlm;
using AppTacOSFinal.Interfaces.Cedis;


namespace AppTacOSFinal.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicContainer;

        public FicViewModelLocator()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            // Registrar cada uno de los ViewModels creados en el siguiente formato
            // builder.RegisterType<ViewModels>();
            builder.RegisterType<FicVmReporteAcumuladosLista>();

            // Servicios
            builder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
            builder.RegisterType<FicSrvApp>().As<ICedis>();

            if (FicContainer != null)
            {
                FicContainer.Dispose();
            }

            FicContainer = builder.Build();
        }

        // Crear los metodos que se mandan llamar desde el archivo xaml.cs de cada vista para
        // ligar el ViewModel con la vista
        public FicVmReporteAcumuladosLista FicVmCedisAlmList
        {
            get { return FicContainer.Resolve<FicVmReporteAcumuladosLista>(); }
        }
    }
}

