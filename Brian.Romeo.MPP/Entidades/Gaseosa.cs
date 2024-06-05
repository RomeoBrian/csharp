using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        protected static bool _deConsumo;
        protected float _litros;
        static Gaseosa()
        {
            _deConsumo = true;
        }
        public Gaseosa() { }
        public Gaseosa(int codigoDeBArra, float precio, EMarcaProducto marca, float litros) : base(codigoDeBArra, precio, marca)
        {
            _litros = litros;
        }
        

        public Gaseosa(Producto producto, float litros) : this(producto.CodigoDeBarra,producto.Precio,producto.Marca, litros)
        {
            _litros = litros;
        }


        public override float CalcularCostoDeProduccion
        {
            get { return Precio * 0.42f; }
            set { Precio = value; }
        }

        private string MostrarGaseosa()
        {
            StringBuilder datosGaseosa = new StringBuilder();
            datosGaseosa.AppendLine((string)this);
            datosGaseosa.AppendLine($"Peso: {_litros}");
            datosGaseosa.AppendLine($"De consumo: {_deConsumo}");
            return datosGaseosa.ToString();
        }

        public override string ToString()
        {
            return MostrarGaseosa();
        }

        public override string Consumir()
        {
            return "Bebible";
        }
    }
}
