using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    class ExcepcionDireccionesYCubetas : Exception
    {
        private static readonly string Mensaje = "Error en una dirección.";
        public int Direccion { get; set; }
        public ExcepcionDireccionesYCubetas(int direccion)
        : base(Mensaje)
        {
            this.Direccion = direccion;
        }
    }
}
