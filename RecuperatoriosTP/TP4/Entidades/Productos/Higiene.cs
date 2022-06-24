using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Productos
{
    public class Higiene : Producto
    {
		public Higiene()
		{

		}
        public Higiene(int id, string descripcion, float precio)
            : base(id, descripcion, precio, ETipo.Higiene) { }

        protected override string Datos(Producto p)
        {
            return base.Datos(p);
        }

        public override string ToString()
        {
            return this.Datos(this);
        }
    }
}
