using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmilceMidence___Examen
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            List<string> nombresProductos = new List<string>();
            List<decimal> preciosProductos = new List<decimal>();
            for (int i = 1; i <= 10; i++)
            {
                TextBox nombreProducto = Controls.Find($"NombreProducto{i}", true).FirstOrDefault() as TextBox;
                TextBox precioProducto = Controls.Find($"PrecioProducto{i}", true).FirstOrDefault() as TextBox;

                if (nombreProducto.Text != "" && precioProducto.Text != "")
                {
                    nombresProductos.Add(nombreProducto.Text);
                    preciosProductos.Add(decimal.Parse(precioProducto.Text));
                }
            }


            decimal totalSinDescuento = preciosProductos.Sum();
            decimal descuento = await CalcularDescuento(totalSinDescuento);
            decimal totalConDescuento = totalSinDescuento - descuento;

            MessageBox.Show($"Total sin descuento: L {totalSinDescuento}\nDescuento del 15%: L {descuento}\nTotal a pagar: L {totalConDescuento}");
        }

        private async Task<decimal> CalcularDescuento(decimal total)
        {
            await Task.Delay(1000);
            return total * 0.15m;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
