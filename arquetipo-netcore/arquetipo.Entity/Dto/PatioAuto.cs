using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Dto
{
    public partial class PatioAuto
    {
        public PatioAuto()
        {
            Ejecutivos = new HashSet<Ejecutivo>();
        }

        public int PaNumeroPatio { get; set; }
        public string PaNombre { get; set; } = null!;
        public string PaDireccion { get; set; } = null!;
        public string PaTelefono { get; set; } = null!;

        public virtual ICollection<Ejecutivo> Ejecutivos { get; set; }
    }
}
