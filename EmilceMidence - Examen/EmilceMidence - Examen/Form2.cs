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
        private List<Producto> productos = new List<Producto>(); // Lista de productos

        public Form2()
        {
            InitializeComponent();

            // Configurar el grid de productos
            gridProductos.Columns.Add("Producto", "Producto");
            gridProductos.Columns.Add("Precio", "Precio unitario");
            gridProductos.Columns[1].DefaultCellStyle.Format = "c";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            var formAgregarProducto = new AgregarProductoForm();
            if (formAgregarProducto.ShowDialog() == DialogResult.OK)
            {
                var producto = formAgregarProducto.GetProducto();
                productos.Add((Producto)producto);
                gridProductos.Rows.Add(producto.Nombre, producto.Precio);
            }
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            double totalVenta = CalcularTotalVenta(); // Calcular el total de la venta

            lblTotalVenta.Text = $"Total de venta: {totalVenta:c}";
            lblDescuento.Text = "Calculando descuento del 15%...";

            double totalConDescuento = await CalcularDescuentoAsync(totalVenta, 0.15); // Llamada a la función asincrónica

            lblDescuento.Text = $"Descuento del 15%: {totalVenta * 0.15:c}";
            lblTotalConDescuento.Text = $"Total con descuento: {totalConDescuento:c}";
        }

        private double CalcularTotalVenta()
        {
            double totalVenta = 0;

            foreach (var producto in productos)
            {
                totalVenta += producto.Precio;
            }

            return totalVenta;
        }

        static async Task<double> CalcularDescuentoAsync(double totalVenta, double porcentajeDescuento)
        {
            await Task.Delay(2000);

            double descuento = totalVenta * porcentajeDescuento;
            double totalConDescuento = totalVenta - descuento;

            return totalConDescuento;
        }
    }

    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }

    public class AgregarProductoForm : Form
    {
        private TextBox txtNombre;
        private NumericUpDown numPrecio;
        private Button btnAceptar;

        internal object GetProducto()
        {
            throw new NotImplementedException();
        }
    }
}
