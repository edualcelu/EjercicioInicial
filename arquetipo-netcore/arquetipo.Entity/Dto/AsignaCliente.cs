using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Dto
{
    public partial class AsignaCliente
    {
        public int AcIDAsignaCliente { get; set; }
        public string AcIdentificacion { get; set; } = null!;
        public int AcNumeroPatio { get; set; }
        public DateTime AcFechaAsignacion { get; set; }

        public virtual Cliente AcIdentificacionNavigation { get; set; } = null!;
        public virtual PatioAuto AcNumeroPatioNavigation { get; set; } = null!;
    }
}
