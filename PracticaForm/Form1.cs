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

            if ((!Funciones.ValidaCuit(cuit)/*negue su valor para provar codigo con cuits falsos*/) && Funciones.ValidarNombreDireccion(nombre,direccion) && Funciones.ValidarCursos(c1,c2,c3))
            {
                string genero = "";
                if (rbFemenino.Checked) genero = rbFemenino.Text.Trim();
                if (rbMasculino.Checked) genero = rbMasculino.Text.Trim();
                if (rbNoBinario.Checked) genero = rbNoBinario.Text.Trim();

                //string c1 = chkc.Checked ? chkc.Text.Trim() : "";
                //string c2 = chkCplus.Checked ? chkCplus.Text.Trim() : "";
                //string c3 = chkJavaScript.Checked ? chkJavaScript.Text.Trim() : "";

                string[] curso = new string[3];
                //if (c1 == "" && c2 == "" && c3 == "")
                //{
                    //MessageBox.Show("Seleccione una opción para curso");
                //}
                //else
                //{
                    curso[0] = c1;
                    curso[1] = c2;
                    curso[2] = c3;
                //}

                string pais = lbPais.Text.Trim();

                Ingresante ing = new Ingresante(nombre, direccion, edad, cuit, genero, pais, curso);

       

          //      if (MessageBox.Show(ing.ToString(), "Datos Ingresante", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                if (Funciones.mAceptar(this, "Datos Ingresante \n" + ing.Mostrar()))
                {
                    //if (MessageBox.Show(ing.ToStringCursos(), "Cursos Inscripto", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    //ing.Guardar();
                    /*if (OperatingSystem.IsWindows())
                    { 
                        string directorio = Directory.GetCurrentDirectory();
                        MessageBox.Show(directorio);
                    }*/
                    char separador = Path.DirectorySeparatorChar;
                    string carpeta = separador+"Inscriptos";
                    string archivo = "";

                    if (ing.Curso[0].CompareTo("C#") == 0)
                    {
                        archivo = "Curso_C#.txt";
                        MessageBox.Show("." + separador + archivo);
                        int registros = 0;
                        HashSet<string> cuitsRegistrados = new HashSet<string>();
                        if (File.Exists("."+separador+archivo))
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
                        }else MessageBox.Show("No se pudo inscribir en Curso C# -->  Persona con mismo CUIT ya inscripta");
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
                    //}
                    //else
                    //{
                    //    MessageBox.Show("verifique los datos e intente nuevamente");
                    //}

                }
                else
                {
                    MessageBox.Show("Datos Descartados");

                    this.Vaciar();

                }

            }
            else
            {
                if (!Funciones.ValidaCuit(cuit))
                    MessageBox.Show("Ingrese un Cuit Valido");
                if (!Funciones.ValidarNombreDireccion(nombre, direccion))
                    MessageBox.Show("Complete los campos de nombre y direccion");
                if (!Funciones.ValidarCursos(c1,c2,c3))
                    MessageBox.Show("Seleccione una opción para curso");
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