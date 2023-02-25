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

        public Form2(object products)
        {
            InitializeComponent();
        }

        public Form2()
        {
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularDescuento();
        }

        private async void CalcularDescuento()
        {
            List<Producto> productos = ObtenerProductos();
            double total = CalcularTotal(productos);

            try
            {
                double descuento = await CalcularDescuentoAsync(total);
                double totalPagar = total - descuento;
                MessageBox.Show($"Descuento aplicado: L {descuento:N2}\nTotal a pagar: L {totalPagar:N2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular descuento: {ex.Message}");
            }
        }

        private List<Producto> ObtenerProductos()
        {
            // Aquí se podría implementar la lógica para obtener los productos y sus precios unitarios.
            // Utilizare una lista predefinida para simplificar el código.
            return new List<Producto>()
    {
        new Producto() { Nombre = "Producto 1", PrecioUnitario = 100.00 },
        new Producto() { Nombre = "Producto 2", PrecioUnitario = 150.00 },
        new Producto() { Nombre = "Producto 3", PrecioUnitario = 200.00 }
    };
        }

        private double CalcularTotal(List<Producto> productos)
        {
            double total = 0.0;
            foreach (Producto producto in productos)
            {
                total += producto.PrecioUnitario;
            }
            return total;
        }

        private async Task<double> CalcularDescuentoAsync(double total)
        {
            await Task.Delay(500); // Simular una operación asíncrona.

            double descuento = total * 0.15;
            return descuento;
        }

        class Producto
        {
            public string Nombre { get; set; }
            public double PrecioUnitario { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 miforma = new Form3();
            miforma.Show();
        }
    }
}

