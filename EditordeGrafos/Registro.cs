using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    internal class Registro
    {
        private int clave;

        public Registro(int clave)
        {
            this.clave = clave;
        }
        public int GetClave() { return clave; }
    }
}
