using System;
using System.Collections.Generic;

namespace PracticaNum6.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdMedico { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Especialidad { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
