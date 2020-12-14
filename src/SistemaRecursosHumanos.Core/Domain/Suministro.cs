using System;
using System.Collections.Generic;

namespace SistemaRecursosHumanos.Core.Domain
{
    public partial class Suministro
    {
        public Suministro()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdSuministro { get; set; }
        public string NombreSuministro { get; set; }
        public int? IdSolicitud { get; set; }

        public virtual Solicitud IdSolicitudNavigation { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
