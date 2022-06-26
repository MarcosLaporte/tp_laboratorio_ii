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

        public override string ToString()
        {
            return this.Datos();
        }
    }
}
