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
        }

        public Form2(object products)
        {
            InitializeComponent();

        }

        private async Task<decimal> CalcularDescuentoAsync(Dictionary<string, decimal> productos)
        {
            // Calculamos el total de la compra
            decimal total = productos.Sum(p => p.Value);

            // Esperamos un segundo para simular una operación larga
            await Task.Delay(1000);

            // Calculamos el descuento del 15%
            decimal descuento = total * 0.15m;

            // Devolvemos el descuento
            return descuento;
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            // Creamos un diccionario para almacenar los productos y sus precios unitarios
            var productos = new Dictionary<string, decimal>();

            // Recorremos los TextBoxes para obtener los nombres de los productos y sus precios unitarios
            foreach (var control in this.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    decimal precio;
                    if (decimal.TryParse(textBox.Text, out precio))
                    {
                        productos[textBox.Name] = precio;
                    }
                }
            }

            // Calculamos el descuento de forma asíncrona
            decimal descuento = await CalcularDescuentoAsync(productos);

            // Calculamos el total a pagar
            decimal total = productos.Sum(p => p.Value) - descuento;

            // Mostramos el resultado en el Label
            lblResultado.Text = $"Descuento: ${descuento:N2}\nTotal a pagar: ${total:N2}";
        }

        private object textBox1_TextChanged(object sender, EventArgs e)
        {
            CalcularDescuentoAsync;
        }
    }
}

