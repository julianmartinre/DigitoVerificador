using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitoVerificador
{
    public static class GestorDigitoVerificador
    {
        public static string CalcularDigitoVerificadorHorizontal(IVerificableEntity entity)
        {
            Type t = entity.GetType();
            string dvh = string.Empty;
            var props = t.GetProperties();

            foreach (var item in props)
            {
                var atributos = item.GetCustomAttributes();
                var verificable = atributos.FirstOrDefault(i => i.GetType().Equals(typeof(PropiedadVerificable)));

                if (verificable != null)
                {
                    if (item.PropertyType.FullName.Equals(typeof(DateTime).FullName))
                    {
                        DateTime a = (DateTime)item.GetValue(entity);
                        dvh += a.ToString("ddmmyyyyhhmmss");
                    }
                    else
                    {
                        dvh += item.GetValue(entity).ToString();
                    }
                }           
            }

            return Criptografia.Hash(dvh);
        }

        //Otra alternativa...
        public static int CalcularDigitoVerificadorHorizontalB(IVerificableEntity entity)
        {
            Type t = entity.GetType();
            string dvh = string.Empty;
            var props = t.GetProperties();

            foreach (var item in props)
            {
                var atributos = item.GetCustomAttributes();
                var verificable = atributos.FirstOrDefault(i => i.GetType().Equals(typeof(PropiedadVerificable)));

                if (verificable != null)
                {
                    if (item.PropertyType.FullName.Equals(typeof(DateTime).FullName))
                    {
                        DateTime a = (DateTime)item.GetValue(entity);
                        dvh += a.ToString("ddmmyyyyhhmmss");
                    }
                    else
                    {
                        dvh += item.GetValue(entity).ToString();
                    }
                }
            }

            char[] caracteres = new char[dvh.Length];
            caracteres = dvh.ToCharArray();
            int contador = 0;

            for (int i = 0; i < dvh.Length; i++)
            {
                int numChar = caracteres[i];
                contador += numChar * 2;
            }

            return (11 - (contador % 11) * dvh.Length);
        }

        public static int CalcularDigitoVerificadorHorizontalC(IVerificableEntity entity)
        {
            string cadena = string.Empty;

            cadena = entity.ToString();

            char[] caracteres = new char[cadena.Length];
            caracteres = cadena.ToCharArray();
            int contador = 0;

            for (int i = 0; i < cadena.Length; i++)
            {
                int numChar = caracteres[i];
                contador += numChar * 2;
            }

            return (11 - (contador % 11) * cadena.Length);
        }
    }
}
