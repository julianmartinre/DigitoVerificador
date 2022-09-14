using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitoVerificador
{
    public class Persona : IVerificableEntity
    {
        public string DNI { get; set; }
        [PropiedadVerificable]
        public string Nombre { get; set; }
        [PropiedadVerificable]
        public string Apellido { get; set; }
        [PropiedadVerificable]
        public DateTime FechaDeNacimiento { get; set; }
        public string DV { get; set; }

        public override string ToString()
        {
            return $"{DNI} {Nombre} {Apellido} {FechaDeNacimiento} {DV}";
        }
    }
}
