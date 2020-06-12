using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTacOSFinal.ViewModels.CedisAlm;
using System;
using AppTacOSFinal.Services.CedisAlm;

namespace AppTacOSFinal.Views.CedisAlm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCedisAlmList : ContentPage
    {
        private object FicParameter { get; set; }
        FicSrvApp service { get; set; }

        public FicViCedisAlmList()
        {
            InitializeComponent();
            BindingContext = App.FicMetLocator.FicVmCedisAlmList;
            this.FicParameter = null;
            service = new FicSrvApp();
        }
        public FicViCedisAlmList(FicViCedisAlmList var)
        {
            InitializeComponent();
            BindingContext = App.FicMetLocator.FicVmCedisAlmList;
            this.FicParameter = null;
            service = new FicSrvApp();
        }
        protected async void FicSearchButtonPressed(object sender, EventArgs e)
        {
            string filtro = FicSearchBar.Text;
            var source = BindingContext as FicVmReporteAcumuladosLista;
            var resultadosCedis = await service.FicMetGetListCedis();
            source.SfDataGrid_ItemSource_Cedis.Clear();
            if (filtro == null || source.SfDataGrid_ItemSource_Cedis == null || filtro == "")
            {
                foreach (var almacen in resultadosCedis)
                {
                    source.SfDataGrid_ItemSource_Cedis.Add(almacen);
                }
                dataGrid.View.Refresh();
                return;
            }
            filtro = filtro.ToLower();
            foreach (var cedi in resultadosCedis)
            {
                if ((cedi.IdCedi + "").ToLower().Contains(filtro) || (cedi.DesCedi + "").ToLower().Contains(filtro) ||
                    (cedi.Activo + "").ToLower().Contains(filtro) || (cedi.Borrado + "").ToLower().Contains(filtro) ||
                    (cedi.UsuarioMod + "").ToLower().Contains(filtro))
                {
                    source.SfDataGrid_ItemSource_Cedis.Add(cedi);
                }
            }
            dataGrid.View.Refresh();
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmReporteAcumuladosLista;
            if (viewModel != null) viewModel.OnAppearing(FicParameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmReporteAcumuladosLista;
            if (viewModel != null) viewModel.OnDisappearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            String filtro = IngresarCediEntry.Text;
            var source = BindingContext as FicVmReporteAcumuladosLista;
            var resultadosAlmacen = await service.FicMetGetListCedis();
            source.SfDataGrid_ItemSource_Cedis.Clear();

            if (filtro == null || source.SfDataGrid_ItemSource_Cedis == null || filtro == "")
            {
                foreach (var almacen in resultadosAlmacen)
                {
                    source.SfDataGrid_ItemSource_Cedis.Add(almacen);
                }
                dataGrid.View.Refresh();
                return;
            }
            filtro = filtro.ToLower();
            foreach (var almacen in resultadosAlmacen)
            {
                if ((almacen.IdCedi + "")
                    .Equals(filtro))
                {
                    source.SfDataGrid_ItemSource_Cedis.Add(almacen);
                }
            }
            dataGrid.View.Refresh();

        }


    }
}