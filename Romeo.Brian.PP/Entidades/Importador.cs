using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        #region Atributos
        private EPaises _paisOrigen;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructores de instancia vacio
        /// </summary>
        public Importador() { }
        /// <summary>
        /// Constructor de instancia con los valores del padre Comercio y pais de origen
        /// </summary>
        /// <param name="nombreComercio"></param>
        /// <param name="precioAlquiler"></param>
        /// <param name="comerciente"></param>
        /// <param name="paisOrigen"></param>
        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciente, EPaises paisOrigen) : base(nombreComercio,comerciente,precioAlquiler)
        {
            _paisOrigen = paisOrigen;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo Para mostrar todos los atributos de la clase
        /// </summary>
        /// <returns>string con los metodos</returns>
        public string Mostrar()
        {
            StringBuilder datosImportador = new StringBuilder();
            datosImportador.Append((string)this);
            datosImportador.AppendLine($"Tipo de producto: {_paisOrigen}");

            return datosImportador.ToString();
        }
        /// <summary>
        /// Metodo para sobrecargar el operador ==
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns>un booleano si se cumple la condicion</returns>
        public static bool operator ==(Importador i1, Importador i2)
        {
            return i1.Equals(i2) && i1._paisOrigen == i2._paisOrigen;
        }
        /// <summary>
        /// sobrecarga del operador !=
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns>true si el comercio y el tipo no son iguales</returns>
        public static bool operator !=(Importador i1, Importador i2)
        {
            return !(i1 == i2);
        }
        /// <summary>
        /// operador implicito de pais de origen
        /// </summary>
        /// <param name="i"></param>
        public static implicit operator EPaises(Importador i)
        {
            return i._paisOrigen;
        }
        #endregion
    }
}
