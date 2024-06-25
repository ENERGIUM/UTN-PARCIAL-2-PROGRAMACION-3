using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticaForm
{
    internal static class Funciones
    {
        /*
      <summary>
       Calcula el dígito verificador dado un CUIT completo o sin él.
       </summary>
       <param name="cuit">El CUIT como String sin guiones</param>
       <returns>El valor del dígito verificador calculado.</returns>
       */

        private static int CalcularDigitoCuit(string cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;

            for (int i = 0; i < mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }

            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
        }


        /* <summary>
         Valida el CUIT ingresado.
         </summary>
         <param name="cuit" />Número de CUIT como string con o sin guiones
         <returns>True si el CUIT es válido y False si no.</returns>
        */
        public static bool ValidaCuit(string cuit)
        {
            if (cuit == null)
            {
                return false;
            }
            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else
            {
                int calculado = CalcularDigitoCuit(cuit);
                int digito = int.Parse(cuit.Substring(10));
                return calculado == digito;
            }
        }

        public static bool ValidarNombreDireccion(string nombre, string direccion)
        {
            if (nombre == "" || direccion == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidarCursos(string c1, string c2, string c3)
        {
            if (c1 == "" && c2 == "" && c3 == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void mError(Form actual, string mensaje)
        {
            MessageBox.Show(actual, mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //Para mostrar mensaje de confirmación
        public static void mOk(Form actual, string mensaje)
        {
            MessageBox.Show(actual, mensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static bool mConsulta(Form actual, string mensaje)
        {
            if (MessageBox.Show(actual, mensaje, "CONSULTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void mAdvertencia(Form actual, string mensaje)
        {
            MessageBox.Show(actual, mensaje, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static bool mAceptar(Form actual, string mensaje)
        {
            if (MessageBox.Show(actual, mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int LeerRegistros(StreamReader linea, HashSet<string> cuitsRegistrados)
        {
            string data = "";
            int registros = 0;
            try
            {
                while (data != null)
                {
                    data = linea.ReadLine();
                    if (data != null)
                    {
                        //MessageBox.Show(data);
                        int d1 = data.IndexOf('|');
                        int d2 = data.IndexOf('|', d1 + 1);
                        int d3 = data.IndexOf('|', d2 + 1);
                        int d4 = data.IndexOf('|', d3 + 1);
                        string cuitPersonasRegistradas = data.Substring(d3 + 1, (d4 - d3 - 1));
                        //MessageBox.Show(cuitPersonasRegistradas);
                        cuitsRegistrados.Add(cuitPersonasRegistradas);
                        registros++;
                    }
                }
                //MessageBox.Show($"{registros}");
                linea.Close();
                linea.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un error inesperado\n"+ ex.Message+"\n"+ ex.ToString()+"\n"+ ex.HResult+"\n");
            }
            finally
            {
                linea.Close();
                linea.Dispose();
            }
            return registros;
        }

        public static void EscribirRegistro(StreamWriter streamWriter, Ingresante ing, int curso)
        {
            try
            {
                streamWriter.WriteLine(ing.Nombre + "|" + ing.Direccion + "|" + ing.Edad + "|" + ing.Cuit + "|" + ing.Pais + "|" + ing.Genero + "|" + ing.Curso[curso]);
                streamWriter.Close();
                streamWriter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un error inesperado\n" + ex.Message + "\n" + ex.ToString() + "\n" + ex.HResult + "\n");
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

        public static void LeerRegistrosYSerializarXML(StreamReader linea, Ingresante inscripto, string rutaArchivoXML, int numeroCurso)
        {
            string data = "";
            bool flagCorrecto = true;
            try
            {
                try
                {
                    if (File.Exists(rutaArchivoXML))
                    {
                        File.Delete(rutaArchivoXML);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Error, no se tienen permisos suficientes para leer ni escribir en el directorio ");
                }
                catch (IOException ex)
                {
                    MessageBox.Show("El archivo está en uso por otro proceso o ocurrió un error de E/S.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A ocurrido un error inesperado\n" + ex.Message + "\n" + ex.ToString() + "\n" + ex.HResult + "\n");
                }
                while (data != null)
                {
                    data = linea.ReadLine();
                    if (data != null)
                    {
                        //MessageBox.Show(data);
                        int d1 = data.IndexOf('|');
                        inscripto.Nombre = data.Substring(0, d1);
                        int d2 = data.IndexOf('|', d1 + 1);
                        inscripto.Direccion = data.Substring(d1+1, d2-d1-1);
                        int d3 = data.IndexOf('|', d2 + 1);
                        inscripto.Edad = int.Parse((data.Substring(d2 + 1, d3 - d2 - 1)));
                        int d4 = data.IndexOf('|', d3 + 1);
                        inscripto.Cuit = data.Substring(d3 + 1, (d4 - d3 - 1));
                        int d5 = data.IndexOf('|', d4 + 1);
                        inscripto.Pais = data.Substring(d4 + 1, (d5 - d4 - 1));
                        int d6 = data.IndexOf('|', d5 + 1);
                        inscripto.Genero = data.Substring(d5 + 1, (d6 - d5 - 1));
                        int d7 = data.Length;
                        inscripto.Curso[numeroCurso] = data.Substring(d6 + 1, (d7 - d6 - 1));
                        //MessageBox.Show(inscripto.Mostrar());

                        StreamWriter streamWriter = null;
                        try
                        {
                            using (streamWriter = new StreamWriter(rutaArchivoXML, true))
                            {
                                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Ingresante));
                                xmlSerializer.Serialize(streamWriter, inscripto);
                            }
                            streamWriter.Close();
                            streamWriter.Dispose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A ocurrido un error inesperado\n" + ex.Message + "\n" + ex.ToString() + "\n" + ex.HResult + "\n");
                            flagCorrecto = false;
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
                }
                if (flagCorrecto)
                {
                    MessageBox.Show("Serializacion XML Realizada con Exito");
                }
                linea.Close();
                linea.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un error inesperado\n" + ex.Message + "\n" + ex.ToString() + "\n" + ex.HResult + "\n");
            }
            finally
            {
                linea.Close();
                linea.Dispose();
            }
        }

        public static void LeerRegistrosYSerializarJSON(StreamReader linea, Ingresante inscripto, string rutaArchivoJSON, int numeroCurso)
        {
            string data = "";
            bool flagCorrecto = true;
            try
            {
                try
                {
                    if (File.Exists(rutaArchivoJSON))
                    {
                        File.Delete(rutaArchivoJSON);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Error, no se tienen permisos suficientes para leer ni escribir en el directorio ");
                }
                catch (IOException ex)
                {
                    MessageBox.Show("El archivo está en uso por otro proceso o ocurrió un error de E/S.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A ocurrido un error inesperado\n" + ex.Message + "\n" + ex.ToString() + "\n" + ex.HResult + "\n");
                }
                while (data != null)
                {
                    data = linea.ReadLine();
                    if (data != null)
                    {
                        //MessageBox.Show(data);
                        int d1 = data.IndexOf('|');
                        inscripto.Nombre = data.Substring(0, d1);
                        int d2 = data.IndexOf('|', d1 + 1);
                        inscripto.Direccion = data.Substring(d1 + 1, d2 - d1 - 1);
                        int d3 = data.IndexOf('|', d2 + 1);
                        inscripto.Edad = int.Parse((data.Substring(d2 + 1, d3 - d2 - 1)));
                        int d4 = data.IndexOf('|', d3 + 1);
                        inscripto.Cuit = data.Substring(d3 + 1, (d4 - d3 - 1));
                        int d5 = data.IndexOf('|', d4 + 1);
                        inscripto.Pais = data.Substring(d4 + 1, (d5 - d4 - 1));
                        int d6 = data.IndexOf('|', d5 + 1);
                        inscripto.Genero = data.Substring(d5 + 1, (d6 - d5 - 1));
                        int d7 = data.Length;
                        inscripto.Curso[numeroCurso] = data.Substring(d6 + 1, (d7 - d6 - 1));
                        //MessageBox.Show(inscripto.Mostrar());

                        StreamWriter streamWriter = null;
                        try
                        {
                            using (streamWriter = new StreamWriter(rutaArchivoJSON, true))
                            {
                                string jsonString = JsonSerializer.Serialize(inscripto);
                                streamWriter.WriteLine(jsonString);
                            }
                            streamWriter.Close();
                            streamWriter.Dispose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A ocurrido un error inesperado\n" + ex.Message + "\n" + ex.ToString() + "\n" + ex.HResult + "\n");
                            flagCorrecto = false;
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
                }
                if (flagCorrecto)
                {
                    MessageBox.Show("Serializacion JSON Realizada con Exito");
                }
                linea.Close();
                linea.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un error inesperado\n" + ex.Message + "\n" + ex.ToString() + "\n" + ex.HResult + "\n");
            }
            finally
            {
                linea.Close();
                linea.Dispose();
            }
        }
    }
}
