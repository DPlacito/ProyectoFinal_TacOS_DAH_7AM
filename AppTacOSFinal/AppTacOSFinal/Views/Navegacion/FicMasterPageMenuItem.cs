using System;
using AppTacOSFinal.Views.CedisAlm;

namespace AppTacOSFinal.Views.Navegacion
{

    public class FicMasterPageMenuItem
    {
        public FicMasterPageMenuItem()
        {
            TargetType = typeof(FicViCedisAlmList);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Icon { get; set; }

        public string FicPageName { get; set; }
    }
}