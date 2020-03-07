using System;
using System.Collections.Generic;

namespace tareaitla2.Models
{
    public partial class DatosEstudiante
    {
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set ; }
        public string Carrera { get; set; }
    }
}
