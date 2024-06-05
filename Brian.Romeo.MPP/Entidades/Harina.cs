using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina : Producto
    {
        protected static bool _deConsumo;
        protected ETipoHarina _tipo;

        public Harina() { }

        static Harina()
        {
            _deConsumo = false;
        }

        public Harina(int codigoDeBArra, float precio, EMarcaProducto marca, ETipoHarina tipo) : base(codigoDeBArra, precio, marca)
        {
            _tipo = tipo;
        }

        public override float CalcularCostoDeProduccion
        {
            get { return Precio * 0.60f; }
            set { Precio = value; }
        }

        private string MostrarHarina()
        {
            StringBuilder datosHarina = new StringBuilder();
            datosHarina.AppendLine((string)this);
            datosHarina.AppendLine($"Tipo de Harina: {_tipo}");
            datosHarina.AppendLine($"De consumo: {_deConsumo}");
            return datosHarina.ToString();
        }

        public override string ToString()
        {
            return MostrarHarina();
        }
    }
}
