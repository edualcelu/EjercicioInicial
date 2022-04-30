using System;

namespace arquetipo.Entity.Dto
{
    public partial class SolicitudCredito
    {
        public int ScIdSolicitudCredito { get; set; }
        public DateTime ScFechaElaboracion { get; set; }
        public string ScIdentificacionCliente { get; set; } = null!;
        public int ScNumeroPatio { get; set; }
        public string ScPlaca { get; set; } = null!;
        public int ScMesesPlazo { get; set; }
        public int ScCuotas { get; set; }
        public decimal ScEntrada { get; set; }
        public string ScIdentificacionEjecutivo { get; set; } = null!;
        public string ScEstadoSolicitud { get; set; } = null!; 
        public string? ScObservacion { get; set; }
        public bool? ScSolicitudActiva { get; set; }

        public virtual Cliente ScIdentificacionClienteNavigation { get; set; } = null!;
        public virtual Ejecutivo ScIdentificacionEjecutivoNavigation { get; set; } = null!;
        public virtual PatioAuto ScNumeroPatioNavigation { get; set; } = null!;
        public virtual Automovil ScPlacaNavigation { get; set; } = null!;
    }
}
