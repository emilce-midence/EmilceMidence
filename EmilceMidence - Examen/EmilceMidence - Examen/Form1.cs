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
    public partial class Form1 : Form
    {
        private CalculadoraInteres calculadora;

        public Form1()
        {
            InitializeComponent();
            calculadora = new CalculadoraInteres();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Obtener el capital y la tasa de interés mensual
            double capital = 200000.00;
            double tasaInteresMensual = 0.015;

            // Recorrer los meses del año y calcular el interés mensual
            for (int mes = 1; mes <= 12; mes++)
            {
                DateTime fecha = new DateTime(2023, mes, 1);
                double interesMensual = calculadora.CalcularInteresMensual(capital, tasaInteresMensual);
                string resultado = string.Format("{0} - L {1:N2}", fecha.ToString("MMMM"), interesMensual);
                lstIntereses.Items.Add(resultado);
            }
        }

    }

    public class CalculadoraInteres
    {
        public double CalcularInteresMensual(double capital, double tasaInteresMensual)
        {
            return capital * tasaInteresMensual;
        }
    }
}

