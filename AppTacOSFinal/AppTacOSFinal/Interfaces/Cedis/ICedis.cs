using System.Collections.Generic;
using System.Threading.Tasks;
using AppTacOSFinal.Models.Cedis;
using System;

namespace AppTacOSFinal.Interfaces.Cedis
{
    public interface ICedis
    {
        Task<List<CediAlmModel>> FicMetGetListCedis();
        Task FicMetGetNewRhCatTelefonos(CediAlmModel item);// CREATE
    }
}
