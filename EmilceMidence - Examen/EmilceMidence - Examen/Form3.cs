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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    lstNumeros.Items.Add($"{i} - Emilce Mainel Midence Calero");
                }
                else if (i % 3 == 0)
                {
                    lstNumeros.Items.Add($"{i} - Emilce");
                }
                else if (i % 5 == 0)
                {
                    lstNumeros.Items.Add($"{i} - Midence");
                }
                else
                {
                    lstNumeros.Items.Add(i.ToString());
                }
            }
        }

    }
}
