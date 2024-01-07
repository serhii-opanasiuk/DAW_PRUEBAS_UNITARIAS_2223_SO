using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBancariaAppNS
{
    public partial class GestionBancariaApp : Form
    {
        private double saldo;  
        //const int ERR_CANTIDAD_NO_VALIDA = 1;
        //const int ERR_SALDO_INSUFICIENTE = 2;
        public const String ERR_CANTIDAD_NO_VALIDA = "Cantidad no válida";
        public const String ERR_SALDO_INSUFICIENTE = "Saldo insuficiente";

        public GestionBancariaApp(double saldo = 0)
        {
            InitializeComponent();
            if (saldo > 0)
                this.saldo = saldo;
            else
                this.saldo = 0;
            txtSaldo.Text = ObtenerSaldo().ToString();
            txtCantidad.Text = "0";
        }

        public double ObtenerSaldo() { return saldo; }

        public int RealizarReintegro(double cantidad) 
        {
            if (cantidad <= 0)
            {
                //return ERR_CANTIDAD_NO_VALIDA;
                throw new ArgumentOutOfRangeException(nameof(cantidad), ERR_CANTIDAD_NO_VALIDA);
            }
            if (saldo < cantidad)
            {
                //return ERR_SALDO_INSUFICIENTE;
                throw new ArgumentOutOfRangeException(nameof(cantidad), ERR_SALDO_INSUFICIENTE);
            }

            //saldo += cantidad; // Error Intencionado
            saldo -= cantidad;
            return 0;
        }

        public int RealizarIngreso(double cantidad) {
            if (cantidad <= 0) //(cantidad > 0) - corregido SO 
            {
                //return ERR_CANTIDAD_NO_VALIDA;
                throw new ArgumentOutOfRangeException(nameof(cantidad), ERR_CANTIDAD_NO_VALIDA);
            }
            saldo += cantidad; //saldo -= cantidad - corregido SO
            return 0;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (rbReintegro.Checked)
            {
                try
                {
                    RealizarReintegro(cantidad);
                    MessageBox.Show("Transacción realizada.", "Reintegro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    if (error.Message.Contains(ERR_SALDO_INSUFICIENTE))
                    {
                        MessageBox.Show("Se ha producido el error: saldo insuficiente", "Error: Saldo insuficiente",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    if (error.Message.Contains(ERR_CANTIDAD_NO_VALIDA))
                    {
                        MessageBox.Show("Se ha producido el error: la cantidad no valida, solo se admiten cantidades positivas",
                            "Error: Número no positivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else {
                try
                {
                    RealizarIngreso(cantidad);
                    MessageBox.Show("Transacción realizada.", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    if (error.Message.Contains(ERR_CANTIDAD_NO_VALIDA))
                    {
                        MessageBox.Show("Se ha producido el error: la cantidad no valida, solo se admiten cantidades positivas",
                            "Error: Número no positivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            txtSaldo.Text = ObtenerSaldo().ToString();
            txtCantidad.Text = "";
        }
    }
}
