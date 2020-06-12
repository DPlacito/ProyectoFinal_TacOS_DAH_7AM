using AppTacOSFinal.Interfaces.SQLite;
using AppTacOSFinal.UWP.SQLite;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicDataBasePathSQLiteUWP))]
namespace AppTacOSFinal.UWP.SQLite
{
    public class FicDataBasePathSQLiteUWP : FicDtaBasePathSQLite
    {
        public string FicGetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, FicAppSettings.FicDatabaseName);
        }//TRAER LA RUTA FISICA DONDE SE GUARDA LA BASE DE DATOS EN UWP
    }
}