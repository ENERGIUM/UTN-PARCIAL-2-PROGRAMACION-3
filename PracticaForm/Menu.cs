using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaForm
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void nuevoRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 registro = new Form1();
            registro.MdiParent = this;
            registro.Show();
        }
    }
}
