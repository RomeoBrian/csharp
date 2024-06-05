using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Exportador : Comercio
    {
        #region Atributos
        private ETipoProducto _tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de instancia Vacio
        /// </summary>
        public Exportador() { }
        /// <summary>
        /// Constructor de instancia con la sobrecarga del padre Comercio
        /// </summary>
        /// <param name="nombreComercio"></param>
        /// <param name="precioAlquiler"></param>
        /// <param name="comerciante"></param>
        /// <param name="tipo"></param>
        public Exportador(string nombreComercio, float precioAlquiler, Comerciante comerciante,ETipoProducto tipo) : base(nombreComercio,comerciante,precioAlquiler)
        { 
            _tipo = tipo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo Para mostrar todos los atributos de la clase
        /// </summary>
        /// <returns>string con los metodos</returns>
        public string Mostrar()
        {
            StringBuilder datosExportador = new StringBuilder();
            datosExportador.Append((string)this);
            datosExportador.AppendLine($"Tipo de producto: {_tipo}");

            return datosExportador.ToString();
        }
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns>true si el Comercio y el tipo son iguales</returns>
        public static bool operator ==( Exportador e1, Exportador e2 )
        {
            return e1.Equals(e2)  && e1._tipo == e2._tipo;
        }
        /// <summary>
        /// sobrecarga del operador !=
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns>true si el comercio y el tipo no son iguales</returns>
        public static bool operator !=(Exportador e1,Exportador e2)
        { 
            return !(e1 == e2); 
        }
        /// <summary>
        /// operador implicito de tipo producto
        /// </summary>
        /// <param name="e"></param>
        public static implicit operator ETipoProducto( Exportador e ) 
        {
            return e._tipo;
        }
        #endregion
    }
}
