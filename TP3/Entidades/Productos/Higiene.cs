using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Productos
{
    public class Higiene : Producto
    {
        public Higiene(string descripcion, float precio)
            : base(descripcion, precio, ETipo.Higiene) { }

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
