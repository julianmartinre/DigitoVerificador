using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitoVerificador
{
    public class Producto : IVerificableEntity
    {
        [PropiedadVerificable]
        public string Nombre { get; set; }
        [PropiedadVerificable]
        public decimal Precio { get; set; }
        public string DV { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Precio} {DV}";
        }
    }
}
