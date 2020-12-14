using System;
using System.Collections.Generic;

namespace SistemaRecursosHumanos.Core.Domain
{
    public partial class RegistroIngreso
    {
        public int IdRegistro { get; set; }
        public string NombreRegistro { get; set; }
        public DateTime? HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public int IdHorario { get; set; }
        public int IdUsuario { get; set; }

        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
