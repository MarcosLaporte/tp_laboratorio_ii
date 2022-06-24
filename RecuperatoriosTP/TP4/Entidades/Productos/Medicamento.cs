using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Productos
{
    public class Medicamento : Producto, IUsoDelProducto
    {
        private int mg;
        private EUso uso;

		public Medicamento()
		{

		}
        public Medicamento(int id, string descripcion, float precio, int mg, EUso uso)
            : base(id, descripcion, precio, ETipo.Medicamento)
        {
            this.Mg = mg;
            this.Uso = uso;
        }

        public int Mg
        {
            get { return this.mg; }
            set { this.mg = value; }
        }
        public EUso Uso
        {
            get { return this.uso; }
            set { this.uso = value; }
        }

        public int AdministrarDosis(EUso uso)
        {
            //Cada cuantas horas
            int ret = 4;
            if(uso == EUso.Analgesico || uso == EUso.Antialergico && this.mg >= 500)
            {
                ret = 8;
            }
            else if(this.mg <= 300)
            {
                ret = 2;
            }
            else if(uso == EUso.Antialergico || uso == EUso.Antibiotico && this.mg >= 1000)
            {
                ret = 12;
            }

            return ret;
        }

        protected override string Datos(Producto p)
        {
            return base.Datos(p) + $"Miligramos: {((Medicamento)p).mg:D}\n" +
                $"Cada {((Medicamento)p).AdministrarDosis(this.uso)} horas.\n";
        }

        public override string ToString()
        {
            return this.Datos(this);
        }
    }
}
