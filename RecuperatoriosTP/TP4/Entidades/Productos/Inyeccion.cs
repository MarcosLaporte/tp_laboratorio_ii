using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Productos
{
    public class Inyeccion : Producto, IUsoDelProducto
    {
        private int cc;
        private EUso uso;

		public Inyeccion()
		{

		}
        public Inyeccion(string descripcion, float precio, int medida, EUso uso)
            : base(descripcion, precio, ETipo.Inyeccion)
        {
            this.Cc = medida;
            this.Uso = uso;
        }

        public int Cc
		{
			get { return this.cc; }
			set { this.cc = value; }
		}
        public EUso Uso
        {
            get { return this.uso; }
            set { this.uso = value; }
        }

        public int AdministrarDosis(EUso uso)
        {
            //Cada cuantos años
            int ret = 1;
            if (uso == EUso.Analgesico || uso == EUso.Antibiotico && this.cc >= 5)
            {
                ret = 3;
            }
            else if (uso == EUso.Antibiotico || uso == EUso.Antialergico && this.cc <= 2)
            {
                ret = 2;
            }
            else if (uso == EUso.Antialergico && this.cc >= 3)
            {
                ret = 5;
            }
            return ret;
        }

        protected override string Datos(Producto p)
        {
            return base.Datos(p) + $"Inyección de {((Inyeccion)p).cc:D}cc\n"
                + $"Cada {((Inyeccion)p).AdministrarDosis(this.uso)} años.\n";
        }

        public override string ToString()
        {
            return this.Datos(this);
        }
    }
}
