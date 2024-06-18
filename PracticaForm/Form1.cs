using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;

namespace PracticaForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btoIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            int edad = (int)nupEdad.Value;
            string cuit = mtbCUIT.Text.Trim();

            string c1 = chkc.Checked ? chkc.Text.Trim() : "";
            string c2 = chkCplus.Checked ? chkCplus.Text.Trim() : "";
            string c3 = chkJavaScript.Checked ? chkJavaScript.Text.Trim() : "";


            try
            {
                if (Funciones.ValidarNombreDireccion(nombre, direccion))
                {
                    throw new DatosInvalidos("Por favor verifique que los campos de Nombre y Direccion esten completos");
                }
                if (Funciones.ValidarCursos(c1, c2, c3))
                {
                    throw new DatosInvalidos("Por favor elija un curso");
                }
                if (!Funciones.ValidaCuit(cuit))
                {
                    throw new DatosInvalidos("Por favor ingrese un cuit valido");

                }

                string genero = "";
                if (rbFemenino.Checked) genero = rbFemenino.Text.Trim();
                if (rbMasculino.Checked) genero = rbMasculino.Text.Trim();
                if (rbNoBinario.Checked) genero = rbNoBinario.Text.Trim();


                string[] curso = new string[3];
                curso[0] = c1;
                curso[1] = c2;
                curso[2] = c3;
                

                string pais = lbPais.Text.Trim();

                Ingresante ing = new Ingresante(nombre, direccion, edad, cuit, genero, pais, curso);


                if (Funciones.mAceptar(this, "Datos Ingresante \n" + ing.Mostrar()))
                {
                    char separador = Path.DirectorySeparatorChar;
                    string carpeta = separador + "Inscriptos";
                    string archivo = "";

                    if (ing.Curso[0].CompareTo("C#") == 0)
                    {
                        archivo = "Curso_C#.txt";
                        MessageBox.Show("." + separador + archivo);
                        int registros = 0;
                        HashSet<string> cuitsRegistrados = new HashSet<string>();
                        if (File.Exists("." + separador + archivo))
                        {
                            StreamReader linea = new StreamReader("." + separador + archivo);
                            registros = Funciones.LeerRegistros(linea, cuitsRegistrados);
                        }
                        if (!cuitsRegistrados.Contains(ing.Cuit))
                        {
                            if (registros < 40)
                            {
                                StreamWriter streamWriter = new StreamWriter("." + separador + archivo, true);
                                Funciones.EscribirRegistro(streamWriter, ing, 0);
                            }
                            else MessageBox.Show("No se pudo inscribir en Curso C#  -->  Cupo Lleno");
                        }
                        else MessageBox.Show("No se pudo inscribir en Curso C# -->  Persona con mismo CUIT ya inscripta");
                    }

                    if (ing.Curso[1].CompareTo("C++") == 0)
                    {
                        archivo = "Curso_C++.txt";
                        MessageBox.Show("." + separador + archivo);
                        int registros = 0;
                        HashSet<string> cuitsRegistrados = new HashSet<string>();
                        if (File.Exists("." + separador + archivo))
                        {
                            StreamReader linea = new StreamReader("." + separador + archivo);
                            registros = Funciones.LeerRegistros(linea, cuitsRegistrados);
                        }
                        if (!cuitsRegistrados.Contains(ing.Cuit))
                        {
                            if (registros < 40)
                            {
                                StreamWriter streamWriter = new StreamWriter("." + separador + archivo, true);
                                Funciones.EscribirRegistro(streamWriter, ing, 1);
                            }
                            else MessageBox.Show("No se pudo inscribir en Curso C++  -->  Cupo Lleno");
                        }
                        else MessageBox.Show("No se pudo inscribir en Curso C++ -->  Persona con mismo CUIT ya inscripta");
                    }

                    if (ing.Curso[2].CompareTo("JavaScript") == 0)
                    {
                        archivo = "Curso_JavaScript.txt";
                        MessageBox.Show("." + separador + archivo);
                        int registros = 0;
                        HashSet<string> cuitsRegistrados = new HashSet<string>();
                        if (File.Exists("." + separador + archivo))
                        {
                            StreamReader linea = new StreamReader("." + separador + archivo);
                            registros = Funciones.LeerRegistros(linea, cuitsRegistrados);
                        }
                        if (!cuitsRegistrados.Contains(ing.Cuit))
                        {
                            if (registros < 40)
                            {
                                StreamWriter streamWriter = new StreamWriter("." + separador + archivo, true);
                                Funciones.EscribirRegistro(streamWriter, ing, 2);
                            }
                            else MessageBox.Show("No se pudo inscribir en Curso JavaScript  -->  Cupo Lleno");
                        }
                        else MessageBox.Show("No se pudo inscribir en Curso JavaScript -->  Persona con mismo CUIT ya inscripta");
                    }
                    this.Vaciar();

                }
                else
                {
                    MessageBox.Show("Datos Descartados");

                    this.Vaciar();

                }
            }
            catch (DatosInvalidos x)
            {
                MessageBox.Show(x.Message);
            }

        }

        internal void Vaciar()
        {
            txtDireccion.Text = "";
            txtNombre.Text = "";
            nupEdad.Value = 18;
            mtbCUIT.Text = "";
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
            rbNoBinario.Checked = false;
            chkc.Checked = false;
            chkCplus.Checked = false;
            chkJavaScript.Checked = false;
            lbPais.Text = "";
        }
    }
}