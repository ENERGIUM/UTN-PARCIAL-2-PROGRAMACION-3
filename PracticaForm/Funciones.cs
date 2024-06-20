using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
    }
}
