using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmilceMidence___Examen
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click_1(object sender, EventArgs e)
        {
            // Obtener el capital inicial y la tasa de interés mensual
            double capital = 200000.00;
            double tasa = 0.015;

            // Crear un arreglo para almacenar los nombres de los meses
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            // Limpiar el ListBox
            lstInteres.Items.Clear();

            // Calcular y mostrar el interés por mes
            for (int i = 0; i < 12; i++)
            {
                // Calcular el interés mensual
                double interes = capital * tasa;

                // Agregar el resultado al ListBox
                lstInteres.Items.Add(meses[i] + ": L " + interes.ToString("0.00"));

                // Actualizar el capital para el siguiente mes
                capital += interes;
            }
        }
    }

}

