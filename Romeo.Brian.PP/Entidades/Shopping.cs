using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Exportador))]
    [XmlInclude(typeof (Importador))]
    public class Shopping
    {
        #region Atributos
        private int _capacidadMaxima;
        private List<Comercio> _comercios;
        #endregion

        #region Contructores
        /// <summary>
        /// Constructor privado vacio que inicializa la lista
        /// </summary>
        private Shopping()
        {
            _comercios = new List<Comercio>();
        }
        /// <summary>
        /// Constructor que inicializa la capacidad maxima y toma el constructor vacio
        /// </summary>
        /// <param name="capacidadMaxima"></param>
        private Shopping(int capacidadMaxima) : this()
        {
            _capacidadMaxima = capacidadMaxima;
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Propiedad para obtener y setear capadidad maxima
        /// </summary>
        public int CapacidadMaxima
        {
            get { return _capacidadMaxima;}
            set {  _capacidadMaxima = value;}
        }
        /// <summary>
        /// Propiedad para poder obtener y setear la lista de comercios
        /// </summary>
        public List<Comercio> Comercios
        {
            get { return _comercios; }
            set { _comercios = value; }
        }
        /// <summary>
        /// propiedad para obtener y setear los precios de los exportadores
        /// </summary>
        public double PrecioDeExportadores
        {
            get { return this.ObtenerPrecio(EComercios.Exportador); }
            set { }
        }
        /// <summary>
        /// Propiedad para obtener y setear los precios de los importadores
        /// </summary>
        public double PrecioDeImportadores
        {
            get { return this.ObtenerPrecio(EComercios.Importador); }
            set { }
        }
        /// <summary>
        /// Propiedad para obtener y setear el precio total de los comercios
        /// </summary>
        public double PrecioTotal
        {
            get { return this.ObtenerPrecio(EComercios.Ambos); }
            set { }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Metodo para mostrar todas los atributos de la clase
        /// </summary>
        /// <param name="shopping"></param>
        /// <returns>String de los atributos</returns>
        public static string Mostrar(Shopping shopping)
        {
            StringBuilder datosShopping = new StringBuilder();
            datosShopping.AppendLine($"Capacidad del Shopping: {shopping.CapacidadMaxima}");
            datosShopping.AppendLine($"Total por importadores: {shopping.PrecioDeImportadores}");
            datosShopping.AppendLine($"Total por Exportadores: {shopping.PrecioDeExportadores}");
            datosShopping.AppendLine($"Total: {shopping.PrecioTotal}");
            datosShopping.AppendLine("***************************");
            datosShopping.AppendLine("Listado de Comercios");
            datosShopping.AppendLine("***************************");
            foreach (Comercio comercio in shopping._comercios)
            {
                if(comercio is Exportador exportador)
                    datosShopping.AppendLine(exportador.Mostrar());
                else if (comercio is Importador importador)
                    datosShopping.AppendLine(importador.Mostrar());
            }

            return datosShopping.ToString();
        }

        /// <summary>
        /// operador implicito de capcidad
        /// </summary>
        /// <param name="i"></param>
        public static implicit operator Shopping(int capacidad)
        {
            Shopping shopping = new Shopping(capacidad);
            return shopping;
        }
        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="shopping"></param>
        /// <param name="comercio"></param>
        /// <returns>true si el comercio se encuentra cargado en el shopping</returns>
        public static bool operator ==(Shopping shopping, Comercio comercio)
        {
            return shopping._comercios.Contains(comercio);
        }
        /// <summary>
        /// sobrecarga del operador !=
        /// </summary>
        /// <param name="shopping"></param>
        /// <param name="comercio"></param>
        /// <returns>true si el comercio no se encuentra cargado en el shopping</returns>
        public static bool operator !=(Shopping shopping, Comercio comercio)
        {
            return !(shopping == comercio);
        }
        /// <summary>
        /// Sobrecarga del operador + para poder sumar a la lista
        /// </summary>
        /// <param name="shopping"></param>
        /// <param name="comercio"></param>
        /// <returns>la clase misma</returns>
        public static Shopping operator +(Shopping shopping, Comercio comercio)
        {
            if (shopping._comercios.Count <= shopping._capacidadMaxima && shopping != comercio)
            {
                shopping._comercios.Add(comercio);
                return shopping;
            }
            Console.WriteLine("No se pudo agregar el Comercio, porque ya se encuentra cargado o la lista llego al maximo");
            return shopping;
        }
        /// <summary>
        /// Metodo para informar el precio total por tipo de comercio
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>devuelve el valor double del precio del alquiler total</returns>
        private double ObtenerPrecio(EComercios tipo)
        {
            double precioAlquilerTotal = 0;
            foreach(Comercio comercio in this._comercios)
            {
                if (tipo == EComercios.Ambos)
                    precioAlquilerTotal += comercio.PrecioAlquiler;
                else if (comercio.GetType().Name == tipo.ToString())
                    precioAlquilerTotal += comercio.PrecioAlquiler;
                
            }
            return precioAlquilerTotal;
        }
        /// <summary>
        /// Metodo para generar y guardar archivo TXT con la informacionm de salida 
        /// </summary>
        /// <param name="rutaArchivo"></param>
        public void GuardarShopping(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {
                    fileStream.Close();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                streamWriter.WriteLine(Mostrar(this));
            }
        }
        /// <summary>
        /// Metodo para Serializar la Clase Shopping, y mostrar todos los atributos de las clases en la lista
        /// </summary>
        /// <param name="path"></param>
        public void SerializarShopping(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                xmlSerializer.Serialize(streamWriter, this);
            }
        }
        /// <summary>
        /// Metodo para poder desSerializar la clase shopping
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Shopping DeserializarShopping(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));

            using (StreamReader streamReader = new StreamReader(path))
            {
                return xmlSerializer.Deserialize(streamReader) as Shopping;
            }
        }

        #endregion
    }
}
