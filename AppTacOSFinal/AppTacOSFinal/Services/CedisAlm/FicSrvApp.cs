using System.Collections.Generic;
using AppTacOSFinal.Data;
using AppTacOSFinal.Interfaces.Cedis;
using System.Threading.Tasks;
using AppTacOSFinal.Models.Cedis;
using AppTacOSFinal.Helpers;
using Xamarin.Forms;
using AppTacOSFinal.Interfaces.SQLite;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text;
using AppTacOSFinal.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Xrm.Sdk.Messages;

namespace AppTacOSFinal.Services.CedisAlm
{
    public class FicSrvApp : ICedis
    {
        private HttpClient FiClient;
        private static readonly FicAsyncLock ficMutex = new FicAsyncLock();
        private FicDBContext FicLoBDContext;
        public FicSrvApp()
        {
            var a = DependencyService.Get<FicDtaBasePathSQLite>().FicGetDatabasePath();
            FicLoBDContext = new FicDBContext(a);
            FiClient = new HttpClient();
            FiClient.MaxResponseContentBufferSize = 256000;
        }

        #region CEDISALM

        public async Task<List<CediAlmModel>> FicMetGetListCedis()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                string url = "http://localhost:55949/api/inventarios/sku_lista";
                var response = await FiClient.GetAsync(url);
                var list = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<CediAlmModel>>(list) : null;
            }
            else
            {

                return await (from inv in FicLoBDContext.CediAlmModel select inv).AsNoTracking().ToListAsync();
            }


        }
        public async Task FicMetGetNewRhCatTelefonos(CediAlmModel usuario)
        {
            await FicMet();
            var usuarios = await (from usu in FicLoBDContext.CediAlmModel select usu).AsNoTracking().ToListAsync();
            usuario.IdCedi = 1;
            if (usuarios.Count != 0)
            {
                var mx_id = usuarios.Max(x => x.IdCedi);
                usuario.IdCedi += mx_id;
            }

            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Add(usuario);
                FicLoBDContext.SaveChanges();
            }
        }
        public async Task FicMet()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<FicDtaBasePathSQLite>().FicGetDatabasePath());
        }
        #endregion
    }
}

