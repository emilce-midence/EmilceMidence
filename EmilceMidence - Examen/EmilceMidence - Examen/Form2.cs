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
            // Obtener los datos de los productos del DataGridView
            BindingList<Producto> productos = new BindingList<Producto>();
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (!row.IsNewRow)
                {
                    Producto producto = new Producto();
                    producto.Nombre = row.Cells[0].Value.ToString();
                    producto.PrecioUnitario = Convert.ToDouble(row.Cells[1].Value);
                    productos.Add(producto);
                }
            }

            // Calcular el total de la factura
            double total = 0;
            foreach (Producto producto in productos)
            {
                total += producto.PrecioUnitario;
            }

            // Calcular el descuento asíncrono
            double descuento = await CalcularDescuentoAsync(total);

            // Mostrar los resultados en etiquetas de texto
            lblDescuento.Text = "Descuento del 15%: L " + descuento.ToString("0.00");
            lblTotalConDescuento.Text = "Total a pagar: L " + (total - descuento).ToString("0.00");
        }

        private async System.Threading.Tasks.Task<double> CalcularDescuentoAsync(double total)
        {
            // Simular una espera de 1 segundo para demostrar la asincronía
            await System.Threading.Tasks.Task.Delay(1000);

            // Calcular el descuento del 15%
            double descuento = total * 0.15;

            // Devolver el resultado
            return descuento;
        }

    }

    public class Producto
    {
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
    }
}

