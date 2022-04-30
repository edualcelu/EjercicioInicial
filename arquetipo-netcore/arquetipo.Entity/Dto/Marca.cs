using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Dto
{
    public partial class Marca
    {
        public Marca()
        {
            Automovils = new HashSet<Automovil>();
        }

        public int MaCodigo { get; set; }
        public string MaNombreMarca { get; set; } = null!;

        public virtual ICollection<Automovil> Automovils { get; set; }
    }
}
