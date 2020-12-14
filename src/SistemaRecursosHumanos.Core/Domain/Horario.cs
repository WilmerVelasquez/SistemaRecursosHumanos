using System;
using System.Collections.Generic;

namespace SistemaRecursosHumanos.Core.Domain
{
    public partial class Horario
    {
        public Horario()
        {
            RegistroIngreso = new HashSet<RegistroIngreso>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdHorario { get; set; }
        public string NombreHorario { get; set; }

        public virtual ICollection<RegistroIngreso> RegistroIngreso { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
