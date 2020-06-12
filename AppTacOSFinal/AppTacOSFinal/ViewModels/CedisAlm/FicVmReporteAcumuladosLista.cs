using AppTacOSFinal.ViewModels.Base;
using AppTacOSFinal.Models.Cedis;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppTacOSFinal.Interfaces.Navigation;
using AppTacOSFinal.Interfaces.Cedis;
using System.Collections.Generic;


using System;



namespace AppTacOSFinal.ViewModels.CedisAlm
{
    public class FicVmReporteAcumuladosLista : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;
        private ICedis FicLoSrvApp;

        private CediAlmModel _Edificios;
        public CediAlmModel Edificio
        {
            get { return _Edificios; }
            set
            {
                _Edificios = value;
                RaisePropertyChanged();
            }
        }

        public FicVmReporteAcumuladosLista(IFicSrvNavigation FicPaSrvNavigation, ICedis FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        private ObservableCollection<CediAlmModel> _SfDataGrid_ItemSource_Cedis;
        public ObservableCollection<CediAlmModel> SfDataGrid_ItemSource_Cedis
        {
            get { return _SfDataGrid_ItemSource_Cedis; }
            set
            {
                _SfDataGrid_ItemSource_Cedis = value;
                RaisePropertyChanged();
            }
        }

        private CediAlmModel _SfDataGrid_SelectItem_Cedis;
        public CediAlmModel SfDataGrid_SelectItem_Cedis
        {
            get { return _SfDataGrid_SelectItem_Cedis; }
            set
            {
                _SfDataGrid_SelectItem_Cedis = value;
                RaisePropertyChanged();
            }
        }

        private ICommand DetailsEdificio;
        public ICommand FicMetDetailsCommand
        {
            get { return DetailsEdificio = DetailsEdificio ?? new FicVmDelegateCommand(DetailsEdificioExecute); }
        }
        private void DetailsEdificioExecute()
        {
            if (SfDataGrid_SelectItem_Cedis != null)
            {
                //FicLoSrvNavigation.FicMetNavigateTo<FicVmCatEdificiosItem>(SfDataGrid_SelectItem_Edificio);
            }
        }
        private ICommand AddEdificio;
        public ICommand FicMetAddCommand
        {
            get { return AddEdificio = AddEdificio ?? new FicVmDelegateCommand(AddEdificioExecuteAsync); }
        }
        private async void AddEdificioExecuteAsync()
        {
            Edificio.IdCedi = 1;
            Edificio.DesCedi = "hola";
            Edificio.Activo = "S";
            Edificio.Borrado = "n";
            DateTime fecha = new DateTime();
            Edificio.FechaReg = fecha;
            Edificio.FechaUltMod = fecha;
            Edificio.UsuarioMod = "yo";
            Edificio.UsuarioReg = "fic";

            await FicLoSrvApp.FicMetGetNewRhCatTelefonos(Edificio);
            FicLoSrvNavigation.FicMetNavigateTo<FicVmReporteAcumuladosLista>(null);
        }
        public async override void OnAppearing(object navigationContext)
        {
            _Edificios = new CediAlmModel();
            var resultadoCedis = await FicLoSrvApp.FicMetGetListCedis();

            SfDataGrid_ItemSource_Cedis = new ObservableCollection<CediAlmModel>();
            foreach (var cedi in resultadoCedis)
            {
                SfDataGrid_ItemSource_Cedis.Add(cedi);
            }
        }
    }
}

