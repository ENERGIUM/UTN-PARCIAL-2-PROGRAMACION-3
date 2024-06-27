using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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

        private char separador = Path.DirectorySeparatorChar;
        private string archivo = "";
        private string archivoXML = "";
        private string archivoJSON = "";

        private void cursoCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo = "Curso_C#.txt";
            archivoXML = "Curso_C#.xml";
            //MessageBox.Show("." + separador + archivo);
            if (File.Exists("." + separador + archivo))
            {
                StreamReader linea = new StreamReader("." + separador + archivo);
                Ingresante inscripto = new Ingresante();
                Funciones.LeerRegistrosYSerializarXML(linea, inscripto, "." + separador + archivoXML, 0);
            }
            else MessageBox.Show("#Error: no existe ningun registro previo para Serializar");
        }

        private void cursoCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            archivo = "Curso_C++.txt";
            archivoXML = "Curso_C++.xml";
            //MessageBox.Show("." + separador + archivo);
            if (File.Exists("." + separador + archivo))
            {
                StreamReader linea = new StreamReader("." + separador + archivo);
                Ingresante inscripto = new Ingresante();
                Funciones.LeerRegistrosYSerializarXML(linea, inscripto, "." + separador + archivoXML, 1);
            }
            else MessageBox.Show("#Error: no existe ningun registro previo para Serializar");
        }

        private void cursoJavascriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo = "Curso_Javascript.txt";
            archivoXML = "Curso_Javascript.xml";
            //MessageBox.Show("." + separador + archivo);
            if (File.Exists("." + separador + archivo))
            {
                StreamReader linea = new StreamReader("." + separador + archivo);
                Ingresante inscripto = new Ingresante();
                Funciones.LeerRegistrosYSerializarXML(linea, inscripto, "." + separador + archivoXML, 2);
            }
            else MessageBox.Show("#Error: no existe ningun registro previo para Serializar");
        }

        private void cursoCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            archivo = "Curso_C#.txt";
            archivoJSON = "Curso_C#.json";
            //MessageBox.Show("." + separador + archivo);
            if (File.Exists("." + separador + archivo))
            {
                StreamReader linea = new StreamReader("." + separador + archivo);
                Ingresante inscripto = new Ingresante();
                Funciones.LeerRegistrosYSerializarJSON(linea, inscripto, "." + separador + archivoJSON, 0);
            }
            else MessageBox.Show("#Error: no existe ningun registro previo para Serializar");
        }

        private void cursoCToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            archivo = "Curso_C++.txt";
            archivoJSON = "Curso_C++.json";
            //MessageBox.Show("." + separador + archivo);
            if (File.Exists("." + separador + archivo))
            {
                StreamReader linea = new StreamReader("." + separador + archivo);
                Ingresante inscripto = new Ingresante();
                Funciones.LeerRegistrosYSerializarJSON(linea, inscripto, "." + separador + archivoJSON, 1);
            }
            else MessageBox.Show("#Error: no existe ningun registro previo para Serializar");
        }

        private void cursoJavascriptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            archivo = "Curso_Javascript.txt";
            archivoJSON = "Curso_Javascript.json";
            //MessageBox.Show("." + separador + archivo);
            if (File.Exists("." + separador + archivo))
            {
                StreamReader linea = new StreamReader("." + separador + archivo);
                Ingresante inscripto = new Ingresante();
                Funciones.LeerRegistrosYSerializarJSON(linea, inscripto, "." + separador + archivoJSON, 2);
            }
            else MessageBox.Show("#Error: no existe ningun registro previo para Serializar");
        }
    }
}
