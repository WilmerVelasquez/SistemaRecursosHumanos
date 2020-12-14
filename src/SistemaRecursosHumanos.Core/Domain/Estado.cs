using System;
using System.Collections.Generic;

namespace SistemaRecursosHumanos.Core.Domain
{
    public partial class Estado
    {
        public Estado()
        {
            Solicitud = new HashSet<Solicitud>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
