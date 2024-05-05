using System;
using System.Collections.Generic;

namespace PracticaNum6.Models
{
    public partial class Cita
    {
        public int IdCita { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public DateTime? FechaHora { get; set; }
        public string? Motivo { get; set; }

        public virtual Medico? IdMedicoNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
    }
}
