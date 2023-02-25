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
        private const double TASA_INTERES_MENSUAL = 0.015;
        private const double CAPITAL_INICIAL = 200000;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Limpiar el ListBox
            lstIntereses.Items.Clear();

            // Calcular el interés para cada mes y mostrar los resultados en el ListBox
            for (int i = 1; i <= 12; i++)
            {
                double interes = CalcularInteresMensual(i);
                string mes = ObtenerNombreMes(i);
                string item = mes + ": L " + interes.ToString("0.00");
                lstIntereses.Items.Add(item);
            }
        }

        private double CalcularInteresMensual(int mes)
        {
            // Calcular el tiempo en meses desde enero de 2023
            int mesesDesdeEnero2023 = (mes - 1);

            // Calcular el período de tiempo en años para el cálculo del interés
            double periodo = mesesDesdeEnero2023 / 12.0;

            // Calcular el interés mensual
            double interes = CAPITAL_INICIAL * TASA_INTERES_MENSUAL * periodo;

            return interes;
        }

        private string ObtenerNombreMes(int mes)
        {
            // Obtener el nombre del mes en función de su número
            string[] nombresMeses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            string nombreMes = nombresMeses[mes - 1];
            return nombreMes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 miforma = new Form2();
            miforma.Show();
        }
    }

}


