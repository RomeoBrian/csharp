using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        protected int _codigoDeBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        public Producto() { }

        public Producto(int codigoDeBArra, float precio, EMarcaProducto marca)
        {
            _codigoDeBarra = codigoDeBArra;
            _marca = marca;
            _precio = precio;
        }

        public EMarcaProducto Marca
        { get { return _marca; } }

        public float Precio
        { 
            get { return _precio; }
            set { _precio = value; }
        }

        public int CodigoDeBarra
        {
            get { return _codigoDeBarra; }
        }
        public abstract float CalcularCostoDeProduccion
        {
            get;    
            set;
        }

        private static string MostrarProducto(Producto p)
        {
            StringBuilder datosProducto = new StringBuilder();
            datosProducto.AppendLine($"Codigo de Barra: {p.CodigoDeBarra}");
            datosProducto.AppendLine($"Marca: {p.Marca}");
            datosProducto.AppendFormat("Precio: ${0:##.##\n}",p.Precio);
            datosProducto.AppendFormat("Precio: ${0:#,###.##\n}", p.Precio);

            return datosProducto.ToString();
        }

        public static bool operator ==(Producto p1, Producto p2)
        {

            return p1.CodigoDeBarra == p2.CodigoDeBarra
                && p1.Marca == p2.Marca
                && p1.Precio == p2.Precio;
        }

        public static bool operator !=(Producto p1, Producto p2)
        { return !(p1 == p2); }

        public static bool operator ==(Producto p1, EMarcaProducto m1)
        {

            return p1.Marca == m1;
        }

        public static bool operator !=(Producto p1, EMarcaProducto m1)
        { return !(p1 == m1); }

        public static explicit operator int(Producto producto) 
        {
            return producto.CodigoDeBarra;
        }

        public static implicit operator string(Producto producto) 
        {
            return MostrarProducto(producto);
        }

        public override bool Equals(object obj)
        {
            return obj is Producto && this == (Producto)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual string Consumir()
        {
            return "parte de una mezcla.";
        }


    }
}
