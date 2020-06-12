using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AppTacOSFinal.Interfaces.SQLite;
using AppTacOSFinal.iOS.SQLite;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicDataBasePathSQLiteiOS))]
namespace AppTacOSFinal.iOS.SQLite
{
    class FicDataBasePathSQLiteiOS : FicDtaBasePathSQLite
    {
        public string FicGetDatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, FicAppSettings.FicDatabaseName);
        }//TRAER LA RUTA FISICA DONDE SE GUARDA LA BASE DE DATOS EN UWP
    }//CLASS
}