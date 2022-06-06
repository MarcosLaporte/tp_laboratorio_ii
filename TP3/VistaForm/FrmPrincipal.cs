using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Productos;

namespace VistaForm
{
    public partial class FrmPrincipal : Form
    {
        private Farmacia<Cliente, Compra, Producto> clientes;
        private Farmacia<Cliente, Compra, Producto> compras;
        private Farmacia<Cliente, Compra, Producto> productos;

        FrmAgregarCliente formAgregarCliente;
        FrmAgregarPedido formAgregarPedido;

        public Farmacia<Cliente, Compra, Producto> Clientes { get => clientes; set => clientes = value; }
        public Farmacia<Cliente, Compra, Producto> Compras { get => compras; set => compras = value; }
        public Farmacia<Cliente, Compra, Producto> Productos { get => productos; set => productos = value; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            clientes = new Farmacia<Cliente, Compra, Producto>();
            compras = new Farmacia<Cliente, Compra, Producto>();
            productos = new Farmacia<Cliente, Compra, Producto>();

            this.HardcodearProductos();
            
            this.lBxClientes.Items.Clear();
            this.lBxCompras.Items.Clear();
        }
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Seguro que desea cerrar la aplicación?",
                        "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            this.formAgregarCliente = new FrmAgregarCliente();
            formAgregarCliente.ShowDialog();

            if (formAgregarCliente.DialogResult == DialogResult.OK)
            {
                Cliente cliente = formAgregarCliente.GetCliente();

                this.clientes += cliente;
                this.lBxClientes.Items.Add(cliente.Dni);
            }
        }

        private void lBxClientes_Click(object sender, EventArgs e)
        {
            object item = this.lBxClientes.SelectedItem;
            if(item is not null)
            {
                Cliente cliente = clientes.GetClientePorDni(clientes, item.ToString());
                if(cliente is null)
                {
                    this.rTBxClientes.Text = "El cliente no existe :(";
                }
                else
                {
                    this.rTBxClientes.Text = cliente.ToString();
                }
            }
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            object item = this.lBxClientes.SelectedItem;
            if (item is not null)
            {
                string stringDni = item.ToString();
                stringDni = stringDni.Trim(new char[] { ' ', '.', ',', '-' });
                Cliente cliente = compras.GetClientePorDni(clientes, stringDni);

                if (cliente is not null)
                {
                    this.formAgregarPedido = new FrmAgregarPedido();
                    this.formAgregarPedido.ProductosDisponibles = productos;
                    this.formAgregarPedido.Cliente = cliente;
                    cliente.Debe += this.formAgregarPedido.Cliente.Debe;

                    formAgregarPedido.ShowDialog();
                    if (formAgregarPedido.DialogResult == DialogResult.OK)
                    {
                        Compra nuevaCompra = formAgregarPedido.CompraCreada;
                        this.compras += nuevaCompra;
                        this.lBxCompras.Items.Add(nuevaCompra.DatosResumidos(nuevaCompra));
                    }
                }
                else
                {
                    MessageBox.Show("El cliente es nulo.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar a un cliente!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHadrdcode_Click(object sender, EventArgs e)
        {
            try
            {
                /*Farmacia<Cliente, Compra, Producto> clientesLeidos = Serializadora<Farmacia<Cliente, Compra, Producto>>.Leer_Json("Cliente");
				foreach (Cliente item in clientesLeidos.ListaClientes)
				{
					this.clientes += item;
					this.lBxClientes.Items.Add(item);
				}*/
                Cliente cliente1 = new Cliente("lucas", "lopez", "11 5284-7986", "26558748");
                Cliente cliente2 = new Cliente("juan", "galate", "11 4758-2404", "98254158");
                Cliente cliente3 = new Cliente("martin", "rocha", "11 5474-4242", "26555898");
                Cliente cliente4 = new Cliente("pepe", "muñoz", "11 1052-7985", "44879465");
                List<Cliente> clientes = new List<Cliente>() { cliente1, cliente2, cliente3, cliente4 };

				foreach (Cliente item in clientes)
				{
                    this.lBxClientes.Items.Add(item.Dni);
					this.clientes += item;
                }

                this.btnHadrdcode.Enabled = false;
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("AAAAAAAAAAAAAA");
            }
        }

        private void lBxCompras_Click(object sender, EventArgs e)
        {

            object item = this.lBxCompras.SelectedItem;
            if (item is not null)
            {
                string stringId = FrmPrincipal.CortarStringEnCaracter(item.ToString(), ':');
                stringId = stringId.Trim(new char[] { '[', ']' });

                if (int.TryParse(stringId, out int id))
                {
                    Compra compra = compras.GetCompraPorId(compras, id);
                    if (compra is null)
                    {
                        this.rTBxCompras.Text = "La compra no existe :(";
                    }
                    else
                    {
                        this.rTBxCompras.Text = compra.MostrarDatos(compra);
                    }
                }
                else
                {
                    this.rTBxCompras.Text = "El id es inválido :(";
                }
            }

            //this.rTBxCompras.Text = nuevaCompra.MostrarDatos(nuevaCompra);

        }

        private void btnBorrarCliente_Click(object sender, EventArgs e)
        {
            object item = this.lBxClientes.SelectedItem;
            if (item is not null)
            {
                string stringDni = item.ToString();
                stringDni = stringDni.Trim(new char[] { ' ', '.', ',', '-' });
                Cliente cliente = compras.GetClientePorDni(clientes, stringDni);

                if (cliente is not null)
                {

                    DialogResult res = MessageBox.Show($"Seguro que desea eliminar a {cliente.Nombre} {cliente.Apellido}?",
                                "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        this.clientes -= cliente;
                        this.lBxClientes.Items.Remove(cliente.Dni);
                    }
                }
                else
                {
                    MessageBox.Show("El cliente es nulo.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar a un cliente!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //MIS FUNCIONES
        public static string CortarStringEnCaracter(string cadena, char caracter)
        {
            string nuevaCadena = "";
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] == caracter)
                {
                    break;
                }
                nuevaCadena += cadena[i];
            }

            return nuevaCadena;
        }

        private void HardcodearProductos()
        {
            this.productos += new Inyeccion("Sinopharm - SARS COV-19", 450, 10, EUso.Antibiotico);
            this.productos += new Medicamento("Ibuprofeno", 200, 200, EUso.Analgesico);
            this.productos += new Inyeccion("Sputnik - SARS COV-19", 300, 5, EUso.Antibiotico);
            this.productos += new Higiene("Rexona 24hs", 750);
            this.productos += new Higiene("Jabón", 230);
            this.productos += new Medicamento("Paracetamol", 620, 500, EUso.Antialergico);
        }
    }
}
