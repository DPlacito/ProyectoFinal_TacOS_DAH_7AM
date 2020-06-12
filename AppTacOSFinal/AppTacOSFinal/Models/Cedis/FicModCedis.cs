using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTacOSFinal.Models.Cedis
{
    public class CediAlmModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdCedi { get; set; }
        [StringLength(50)]
        public string DesCedi { get; set; }
        public DateTime? FechaReg { get; set; }
        public DateTime? FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    public class zt_list_cedis
    {
        public List<CediAlmModel> CediAlmModels { get; set; }

    }
}
