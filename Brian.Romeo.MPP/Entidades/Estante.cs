using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Entidades
{
    [XmlInclude(typeof(Harina))]
    [XmlInclude(typeof(Jugo))]
    [XmlInclude(typeof(Gaseosa))]
    [XmlInclude(typeof(Galletita))]
    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        private Estante()
        {
            _productos = new List<Producto>();
        }

        public Estante(sbyte capacidad)
            : this()
        {
            _capacidad = capacidad;
        }

        public List<Producto> GetProductos()
        {
            return _productos;
        }

        public float ValorEstanteTotal
        {
            get { return GetValorEstante(); }
            set {}
        }

        public List<Producto> Productos 
        { 
            get { return _productos; }
            set { }
        
        }

        public sbyte Capacidad
        { 
            get { return _capacidad; } 
            set { }
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder datosEstante = new StringBuilder();
            
            if (e._productos.Count >0) 
            {
                foreach (Producto productos in e.GetProductos())
                {   
                        datosEstante.AppendLine(productos.ToString());
                }
            }
            else
            {
                datosEstante.AppendLine($"La lista se encuentra vacia");
            }
            
            return datosEstante.ToString();
        }

        public static bool operator ==(Estante e1, Producto p1)
        {
            return e1._productos.Contains(p1); //metodo de lista para retornar si existe o no
        }

        public static bool operator !=(Estante e1, Producto p1) { return !(e1 == p1); }

        public static bool operator +(Estante e1, Producto p1)
        {
            if (e1._productos.Count <= e1._capacidad && e1 != p1)
            {
                e1._productos.Add(p1);
                return true;
            }
            return false;
        }

        public static Estante operator -(Estante e1, Producto p1)
        {
            if (e1 == p1)
            {
                e1._productos.Remove(p1);
            }
            else
            {
                Console.WriteLine("El producto fue removido");
            }

            return e1;
        }
        
        public static Estante operator -(Estante e1, ETipoProducto t1)
        {
            if (t1 == ETipoProducto.Todos)
            {
                e1._productos.Clear();
            }
            else
            {
                for (int i = 0; i < e1._productos.Count(); i++)
                {
                    if (e1._productos[i].GetType().Name == t1.ToString())
                    {
                        e1._productos.RemoveAt(i);
                        i--;
                    }
                }
            }


            /*
                foreach (Producto productos in e1.GetProductos())
            {
                if (productos.GetType().Name == t1.ToString())
                {
                    e1._productos.Remove(productos);
                }
                else if(t1 == ETipoProducto.Todos)
                {
                    e1._productos.Clear();
                    break;
                }
                
            }
            */
            return e1;
        }

        public float GetValorEstante(ETipoProducto tipo)
        {
            float valorTotal = 0;
            foreach (Producto productos in this.GetProductos())
            {
                if (tipo == ETipoProducto.Todos)
                {
                    valorTotal = productos.CalcularCostoDeProduccion;
                }
                else if (productos.GetType().Name == tipo.ToString())
                {
                    valorTotal = productos.CalcularCostoDeProduccion;
                }
            }

            return valorTotal;
        }

        public float GetValorEstante()
        {
            return GetValorEstante(ETipoProducto.Todos);
        }

        public static void GuardarEstante(Estante estante, string rutaArchivo)
        { 
            if(!File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {
                    fileStream.Close();
                }
            }
            
            using(StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                streamWriter.WriteLine(MostrarEstante(estante));
            }
        }

        public static void SerializarEstante(Estante estante, string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Estante));

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                xmlSerializer.Serialize(streamWriter, estante);
            }
        }

        public static Estante DeserializarEstante(string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Estante));
            
            using (StreamReader streamReader = new StreamReader(rutaArchivo))
            {
                return xmlSerializer.Deserialize(streamReader) as Estante;
            }
        }


    }
}
