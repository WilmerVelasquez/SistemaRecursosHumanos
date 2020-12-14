using System;
using System.Collections.Generic;

namespace SistemaRecursosHumanos.Core.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            RegistroIngreso = new HashSet<RegistroIngreso>();
            Solicitud = new HashSet<Solicitud>();
        }

        public int IdUsuario { get; set; }
        public int? NDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public int? IdHorario { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdEstado { get; set; }
        public string AspnetusersId { get; set; }

        public virtual Aspnetusers Aspnetusers { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual Solicitud IdSolicitudNavigation { get; set; }
        public virtual ICollection<RegistroIngreso> RegistroIngreso { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
