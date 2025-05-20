using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    class ExcepcionZocaloInvalido : Exception
    {
        private static readonly string Mensaje = "Zócalo inválido.";
        public int Zocalo { get; set; }
        public ExcepcionZocaloInvalido(int zocalo)
        : base(Mensaje)
        {
            this.Zocalo = zocalo;
        }
    }
}
