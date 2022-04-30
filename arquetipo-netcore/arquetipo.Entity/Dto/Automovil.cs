using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Dto
{
    public partial class Automovil
    {
        public string AuPlaca { get; set; } = null!;
        public string AuModelo { get; set; } = null!;
        public string AuNumeroChasis { get; set; } = null!;
        public int AuCodigoMarca { get; set; }
        public string AuTipo { get; set; } = null!;
        public decimal AuCilindraje { get; set; }
        public decimal AuAvaluo { get; set; }

        public virtual Marca AuCodigoMarcaNavigation { get; set; } = null!;
    }
}
