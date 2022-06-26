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

        /// <summary>
        /// Clasifica los valores de los atributos [uso] y [mg] y, dependiendo de qué
        /// condición cumplan, retorna cada cuantas horas debe administrarse el medicamento.
        /// </summary>
        /// <param name="uso">El valor del enumerado EUso.</param>
        /// <returns>Un entero que representa horas.</returns>
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

        public override string ToString()
        {
            return this.Datos() + $"Miligramos: {this.mg:D}\n" +
                $"Cada {this.AdministrarDosis(this.uso)} horas.\n";
        }
    }
}
