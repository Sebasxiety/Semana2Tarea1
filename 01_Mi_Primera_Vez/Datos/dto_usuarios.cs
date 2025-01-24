using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Mi_Primera_Vez.Datos
{
    public class dto_usuarios
    {
        public int IdUsuario { get; set; }
        public string Cedula { get; set; }
        public string NombresApellidos { get; set; }
        public string DireccionDomicilio { get; set; }
        public string CodigoPostal { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Pais { get; set; }
    }
}
