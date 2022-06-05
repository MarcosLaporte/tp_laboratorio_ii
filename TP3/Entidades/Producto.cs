using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        private static int bancoIds;
        private readonly int id;
        private string descripcion;
        private float precio;
        private ETipo tipo;

        static Producto()
        {
            bancoIds = 1;
        }
        protected Producto(string descripcion, float precio, ETipo tipo)
        {
            this.id = Producto.bancoIds;
            Producto.bancoIds++;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Tipo = tipo;
        }

        public int Id
        {
            get { return this.id; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        public float Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public ETipo Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        protected virtual string Datos(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tipo: {p.tipo}.");
            sb.AppendLine($"Descripción: [{p.id}] {p.descripcion}.");
            sb.AppendLine($"Precio: {p.precio:C}.");

            return sb.ToString();
        }
    }
}
