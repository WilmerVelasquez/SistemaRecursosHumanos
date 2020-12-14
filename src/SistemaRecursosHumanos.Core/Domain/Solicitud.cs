using System;
using System.Collections.Generic;

namespace SistemaRecursosHumanos.Core.Domain
{
    public partial class Solicitud
    {
        public Solicitud()
        {
            Suministro = new HashSet<Suministro>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdSolicitud { get; set; }
        public string NombreSolicitud { get; set; }
        public DateTime? FechaCreada { get; set; }
        public string FechaRespuesta { get; set; }
        public int? IdEstado { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Suministro> Suministro { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
