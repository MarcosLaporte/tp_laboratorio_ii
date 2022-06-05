using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private string telefono;
        private string dni;
        private float debe;

        public Cliente(string nombre, string apellido, string telefono, string dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Dni = dni;
            this.Debe = 0;
        }

        #region Propiedades
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (value is not null)
                {
                    this.nombre = value;
                }
                else
                {
                    throw new NullReferenceException("El nombre no puede ser nulo.");
                }
            }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (value is not null)
                {
                    this.apellido = value;
                }
                else
                {
                    throw new NullReferenceException("El apellido no puede ser nulo.");
                }
            }
        }
        public string Telefono
        {
            get { return this.telefono; }
            set
            {
                if (value is not null)
                {
                    //if (/*formato == todo piola*/)
                        this.telefono = value;
                    //else
                    //    throw new TelefonoInvalidoException();
                }
                else
                {
                    throw new NullReferenceException("El teléfono no puede ser nulo.");
                }
            }
        }
        public string Dni
        {
            get { return this.dni; }
            set
            {
                string dniStr = value;
                if (!String.IsNullOrEmpty(dniStr))
                {
                    this.dni = value;
                }
                else
                {
                    throw new NullReferenceException("El dni no puede ser nulo.");
                }
            }
        }
        public float Debe
        {
            get { return this.debe; }
            set { this.debe = value; }
        }
        #endregion

        private static string MostrarDatos(Cliente cliente)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"-DNI: {cliente.dni}.");
            sb.AppendLine($"-Nombre: {cliente.nombre}.");
            sb.AppendLine($"-Apellido: {cliente.apellido}.");
            sb.AppendLine($"-Telefono: {cliente.telefono}.");
            sb.AppendLine($"-Debe: {cliente.debe:C}.");

            return sb.ToString();
        }

        public static bool operator ==(Cliente a, Cliente b)
        {
            bool ret = false;
            if(a is not null && b is not null)
            {
                if(a.dni == b.dni)
                {
                    ret = true;
                }
            }

            return ret;
        }
        public static bool operator !=(Cliente a, Cliente b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Cliente cliente = obj as Cliente;
            return cliente is not null && cliente == this;
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
