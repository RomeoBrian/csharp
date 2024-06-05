using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        protected static bool _deConsumo;
        protected ESaborJugo _sabor;
        
        static Jugo()
        {
            _deConsumo = true;
        }
        public Jugo() { }

        public Jugo(int codigoDeBArra, float precio, EMarcaProducto marca,  ESaborJugo Sabor) : base(codigoDeBArra, precio, marca)
        {
            _sabor = Sabor;
        }

        public override float CalcularCostoDeProduccion
        {
            get { return Precio * 0.4f; }
            set { Precio = value; } 
        }

        private string MostrarJugo()
        {
            StringBuilder datosJugo = new StringBuilder();
            datosJugo.AppendLine((string)this);
            datosJugo.AppendLine($"Sabor: {_sabor}");
            datosJugo.AppendLine($"De consumo: {_deConsumo}");
            return datosJugo.ToString();
        }

        public override string ToString()
        {
            return MostrarJugo();
        }

        public override string Consumir()
        {
            return "Bebilbe";
        }


    }
}
