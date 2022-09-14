using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitoVerificador
{
    class Program
    {
        static void Main(string[] args)
        {
            //Producto producto = new Producto() { Nombre = "Kiwi", Precio = 200 };
            //producto.DV = GestorDigitoVerificador.CalcularDigitoVerificadorHorizontal(producto);
            //Console.WriteLine(producto.ToString());

            Persona personaA = new Persona() { DNI = "40000000", Nombre = "Juan", Apellido = "Sanchez", FechaDeNacimiento = new DateTime(1993, 11, 04) };
            personaA.DV = GestorDigitoVerificador.CalcularDigitoVerificadorHorizontal(personaA);
            Console.WriteLine(personaA.ToString());

            Persona personaB = new Persona() { DNI = "40000002", Nombre = "Mariano", Apellido = "Perez", FechaDeNacimiento = new DateTime(1994, 10, 05) };
            personaB.DV = GestorDigitoVerificador.CalcularDigitoVerificadorHorizontal(personaB);
            Console.WriteLine(personaB.ToString());

            Persona personaC = new Persona() { DNI = "40000004", Nombre = "Maria", Apellido = "Rodriguez", FechaDeNacimiento = new DateTime(1995, 9, 06) };
            personaC.DV = GestorDigitoVerificador.CalcularDigitoVerificadorHorizontal(personaC);
            Console.WriteLine(personaC.ToString());

            IList<Persona> personas = new List<Persona>
            {
                personaA,
                personaB,
                personaC
            };

            string dvv = string.Empty;

            foreach (var item in personas)
            {
                dvv += item.DV;
            }

            dvv = Criptografia.Hash(dvv);

            Console.WriteLine("\nDVV de personas: {0}\n", dvv);

            Console.WriteLine("Cambiamos un dato de personaC (DNI)");

            personaC.DNI = "40000006";
            personaC.DV = GestorDigitoVerificador.CalcularDigitoVerificadorHorizontal(personaC);
            Console.WriteLine(personaC.ToString());

            Console.WriteLine("Cambiamos otro dato de personaC (Nombre)");

            personaC.Nombre = "María";
            personaC.DV = GestorDigitoVerificador.CalcularDigitoVerificadorHorizontal(personaC);
            Console.WriteLine(personaC.ToString());

            string dvvNuevo = string.Empty;

            foreach (var item in personas)
            {
                dvvNuevo += item.DV;
            }

            dvvNuevo = Criptografia.Hash(dvv);

            Console.WriteLine("\nDVV recalculado de personas: {0}\n", dvvNuevo);

            Console.ReadKey();
        }
    }
}
