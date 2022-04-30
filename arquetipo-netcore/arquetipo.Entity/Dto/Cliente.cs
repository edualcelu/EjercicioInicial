using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Dto
{
    public partial class Cliente
    {
        public string ClIdentificacion { get; set; } = null!;
        public string ClNombres { get; set; } = null!;
        public int ClEdad { get; set; }
        public DateTime ClFechaNacimiento { get; set; }
        public string ClApellidos { get; set; } = null!;
        public string ClDireccion { get; set; } = null!;
        public string ClTelefono { get; set; } = null!;
        public string ClEstadoCivil { get; set; } = null!;
        public string ClIdentificacionConyuge { get; set; } = null!;
        public string ClNombreConyuge { get; set; } = null!;
        public bool ClSujetoCredito { get; set; }
    }
}
