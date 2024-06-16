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
                            string data = "";
                            try
                            {
                                while (data != null)
                                {
                                    data = linea.ReadLine();
                                    if (data != null)
                                    {
                                        MessageBox.Show(data);
                                        int d1 = data.IndexOf('|');
                                        int d2 = data.IndexOf('|', d1 + 1);
                                        int d3 = data.IndexOf('|', d2 + 1);
                                        int d4 = data.IndexOf('|', d3 + 1);
                                        string cuitPersonasRegistradas = data.Substring(d3 + 1, (d4 - d3 - 1));
                                        MessageBox.Show(cuitPersonasRegistradas);
                                        cuitsRegistrados.Add(cuitPersonasRegistradas);
                                        registros++;
                                    }
                                }
                                MessageBox.Show($"{registros}");
                                linea.Close();
                                linea.Dispose();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                Console.WriteLine(ex.HResult);
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                linea.Close();
                                linea.Dispose();
                            }
                            
                        }
                        if (!cuitsRegistrados.Contains(ing.Cuit))
                        {
                            if (registros < 40)
                            {
                                StreamWriter streamWriter = new StreamWriter("." + separador + archivo, true);
                                try
                                {
                                    streamWriter.WriteLine(ing.Nombre + "|" + ing.Direccion + "|" + ing.Edad + "|" + ing.Cuit + "|" + ing.Pais + "|" + ing.Genero + "|" + ing.Curso[0]);
                                    streamWriter.Close();
                                    streamWriter.Dispose();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.ToString());
                                    Console.WriteLine(ex.HResult);
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {
                                    if (streamWriter is not null)
                                    {
                                        streamWriter.Close();
                                        streamWriter.Dispose();
                                    }
                                }
                            }
                            else MessageBox.Show("No se pudo inscribir  -->  Cupo Lleno");
                        }else MessageBox.Show("No se pudo inscribir  -->  Persona con mismo cuit ya inscripta");
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