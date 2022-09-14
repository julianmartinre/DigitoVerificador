using System;
using System.Collections.Generic;
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

        public static string CalcularDigitoVerificadorVertical(IList<IVerificableEntity> entities)
        {
            string dvv = string.Empty;

            foreach (var item in entities)
            {
                dvv += CalcularDigitoVerificadorHorizontal(item);
            }

            return Criptografia.Hash(dvv);
        }
    }
}
