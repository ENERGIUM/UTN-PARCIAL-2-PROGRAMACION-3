using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaForm
{
    internal class DatosInvalidos : Exception
    {
        public DatosInvalidos( string mensaje) : base(mensaje){
        }
    }
}
