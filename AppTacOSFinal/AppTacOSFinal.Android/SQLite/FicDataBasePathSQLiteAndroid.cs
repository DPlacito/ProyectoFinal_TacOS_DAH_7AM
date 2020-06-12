using AppTacOSFinal.Interfaces.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppTacOSFinal.Droid.SQLite;

using Xamarin.Forms;

[assembly: Dependency(typeof(FicDataBasePathSQLiteAndroid))]
namespace AppTacOSFinal.Droid.SQLite
{
    class FicDataBasePathSQLiteAndroid : FicDtaBasePathSQLite
    {
        public string FicGetDatabasePath()
        {

            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "DB_COCACOLA_NAY.db3");
            /* var FicExternalPath = Android.OS.Environment.DirectoryDownloads + Java.IO.File.Separator + FicAppSettings.FicDatabaseName;


             FicExternalPath = FicExternalPath + Java.IO.File.Separator + FicAppSettings.FicDatabaseName;
             return FicExternalPath;*/


        }
    }

}