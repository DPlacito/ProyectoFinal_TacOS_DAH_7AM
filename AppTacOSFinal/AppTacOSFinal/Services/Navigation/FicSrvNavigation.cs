using AppTacOSFinal.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using AppTacOSFinal.ViewModels.CedisAlm;
using AppTacOSFinal.Views.CedisAlm;

namespace AppTacOSFinal.Services.Navigation
{
    public class FicSrvNavigation : IFicSrvNavigation
    {

        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            // Registrar la relación ViewModel - Vista en el siguiente formato para cada vista
            { typeof(FicVmReporteAcumuladosLista), typeof(FicViCedisAlmList) }
        };

        public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;//MasterDetailPage

            /*if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);*/
            if (page != null)
            {
                var mpd = Application.Current.MainPage as MasterDetailPage;
                mpd.Detail.Navigation.PushAsync(page);
            }
        }

        public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null, bool show = true)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext, show) as Page;

            /*if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);*/
            if (page != null)
            {
                var mpd = Application.Current.MainPage as MasterDetailPage;
                mpd.Detail.Navigation.PushAsync(page);
            }
        }

        public void FicMetNavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            /*if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);*/
            if (page != null)
            {
                var mpd = Application.Current.MainPage as MasterDetailPage;
                mpd.Detail.Navigation.PushAsync(page);
            }
        }

        public void FicMetNavigateBack()
        {
            //Application.Current.MainPage.Navigation.PopAsync();
            var mpd = Application.Current.MainPage as MasterDetailPage;
            mpd.Detail.Navigation.PopAsync();

        }
    }
}

