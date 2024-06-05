using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        #region atributos
        private string _apellido;
        private string _nombre;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Comerciante() { }
        /// <summary>
        /// Constructor donde se inizializan los atributos
        /// </summary>
        /// <param name="apellido"></param>
        /// <param name="nombre"></param>
        public Comerciante(string apellido, string nombre)
        {
            _apellido = apellido;
            _nombre = nombre;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo apellido
        /// </summary>
        public string Apellido 
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        /// <summary>
        /// Propiedad del atributo nombre
        /// </summary>
        public string Nombre
        { 
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion
        
        #region Metodos
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="c1">Comerciante 1</param>
        /// <param name="c2">Comerciante 2</param>
        /// <returns>true Si los nombres y apellidos coinciden</returns>
        public static bool operator ==(Comerciante c1, Comerciante c2)
        {

            return c1.Apellido == c2.Apellido && c1.Nombre == c2.Nombre;
        }
        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="c1">Comerciante 1</param>
        /// <param name="c2">Comerciante 2</param>
        /// <returns>true Si los nombres y apellidos no coinciden</returns>
        public static bool operator !=(Comerciante c1, Comerciante c2) 
        {  
            return !(c1 == c2); 
        }
        /// <summary>
        /// Metodo para poder sobrecargar de forma implicita el operador string y devolver la cadena armada
        /// </summary>
        /// <param name="comerciente"></param>
        public static implicit operator string(Comerciante comerciente)
        {
            StringBuilder datosComerciente = new StringBuilder();
            datosComerciente.AppendLine($"Comerciante: {comerciente.Nombre} {comerciente.Apellido}");
            return datosComerciente.ToString();
        }
        #endregion
    }
}
