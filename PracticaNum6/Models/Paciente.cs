using System;
using System.Collections.Generic;

namespace PracticaNum6.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
