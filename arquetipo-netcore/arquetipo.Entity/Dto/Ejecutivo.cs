using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Dto
{
    public partial class Ejecutivo
    {
        public string EIdentificacion { get; set; } = null!;
        public string ENombres { get; set; } = null!;
        public string EApellidos { get; set; } = null!;
        public string EDireccion { get; set; } = null!;
        public string ETelefonoConvencional { get; set; } = null!;
        public string ECelular { get; set; } = null!;
        public int ENumeroPatio { get; set; }
        public int EEdad { get; set; }

        public virtual PatioAuto ENumeroPatioNavigation { get; set; } = null!;
    }
}
