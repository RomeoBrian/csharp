using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
        protected static bool _deConsumo;
        protected float _peso;

        static Galletita()
        {
            _deConsumo = true;
        }
        public Galletita() { }
        public Galletita(int codigoDeBArra, float precio, EMarcaProducto marca, float peso) : base(codigoDeBArra, precio, marca)
        {
            _peso = peso;
        }

        public override float CalcularCostoDeProduccion
        {
            get { return Precio * 0.33f; }
            set { Precio = value; }
        }

        private static string MostrarGalletita(Galletita galletita)
        {
            StringBuilder datosGalletita = new StringBuilder();
            datosGalletita.AppendLine((string)galletita);        
            datosGalletita.AppendLine($"Peso: {galletita._peso}");
            datosGalletita.AppendLine($"De consumo: {_deConsumo}");
            return datosGalletita.ToString();
        }

        public override string ToString()
        {
            return MostrarGalletita(this);
        }

        public override string Consumir()
        {
            return "Comestible";
        }
    }
}
