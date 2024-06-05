using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Comercio
    {
        #region Atributos
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected static Random _generadorDeEmpleados;
        protected string _nombre;
        protected float _precioAlquiler;
        #endregion

        #region Constructores
        /// <summary>
        /// Construnctor estatico que inicializa el generadorDeEmpleados
        /// </summary>
        static Comercio () 
        {
            _generadorDeEmpleados = new Random();
        }
        /// <summary>
        /// Constructor de instancia vacio
        /// </summary>
        public Comercio() { }
        /// <summary>
        /// Sobrecarga de construnctor de instancia con la clase 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="comerciente"></param>
        /// <param name="precioAlquiler"></param>
        public Comercio(string nombre, Comerciante comerciente, float precioAlquiler) : this()
        {
            _nombre = nombre;
            _comerciante = comerciente;
            _precioAlquiler = precioAlquiler;

        }

        /// <summary>
        /// Sobrecarga Constructor de instancia sin pasarle la clase
        /// </summary>
        /// <param name="precioAlquiler"></param>
        /// <param name="nombreComercio"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido) : this (nombreComercio, new Comerciante(nombre,apellido), precioAlquiler)
        {
            _precioAlquiler = precioAlquiler;
            _nombre = nombreComercio;
            Comerciante _comerciante = new Comerciante(nombre,apellido);
        }
        

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad  para inicializar de Cantidad De Empleados
        /// </summary>
        public int CantidadDeEmpleados
        {
            get 
            { 
                if (_cantidadDeEmpleados == 0)
                   return _cantidadDeEmpleados = _generadorDeEmpleados.Next(1,100);
                else
                    return _cantidadDeEmpleados;
            }
            set
            {
                _cantidadDeEmpleados = value;
            }
        }
        /// <summary>
        /// Propiedad  para inicializar de comerciante
        /// </summary>
        public Comerciante Comerciante
        {
            get { return _comerciante;}
            set { _comerciante = value;}
        }
        /// <summary>
        /// Propiedad  para inicializar de Nombre del comercio
        /// </summary>
        public string Nombre
        { 
            get { return _nombre; } 
            set { _nombre = value; } 
        }
        /// <summary>
        /// Propiedad  para inicializar de Precio alquiler
        /// </summary>
        public float PrecioAlquiler
        {
            get { return _precioAlquiler;}
            set { _precioAlquiler = value;}
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo Mostrar, mostrara todos los atributos de la clase
        /// </summary>
        /// <returns> Un string con todos los atributos</returns>
        private string Mostrar()
        {
            StringBuilder datosComercio = new StringBuilder();
            datosComercio.AppendLine($"Nombre Comercio: {Nombre}");
            datosComercio.Append((string)Comerciante);
            datosComercio.AppendLine($"Cantidad de empleados: {CantidadDeEmpleados}");
            
            return datosComercio.ToString();
        }
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns> true si Los objetos son iguales</returns>
        public static bool operator ==(Comercio c1, Comercio c2)
        {

            return c1.Nombre == c2.Nombre && c1.Comerciante == c2.Comerciante;
        }
        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns> true si Los objetos no son iguales</returns>
        public static bool operator !=(Comercio c1, Comercio c2) 
        { 
            return !(c1 == c2); 
        }
        /// <summary>
        /// Sobrecarga del operador explicito string 
        /// </summary>
        /// <param name="c"></param>
        /// <returns> Se genera un string con toda la informacion</returns>
        public static explicit operator string(Comercio c) 
        {
            return c.Mostrar();
        }
        /// <summary>
        /// Sobrecarga del metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Devuelve un true si esta correcto</returns>
        public override bool Equals(object obj)
        {
            return obj is Comercio && this == (Comercio)obj;
        }
        #endregion

    }
}

