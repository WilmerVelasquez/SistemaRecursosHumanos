using System;
using System.Collections.Generic;

namespace SistemaRecursosHumanos.Core.Domain
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? CantidadDisponible { get; set; }
        public string Medidas { get; set; }
        public int? IdSuministro { get; set; }

        public virtual Suministro IdSuministroNavigation { get; set; }
    }
}
