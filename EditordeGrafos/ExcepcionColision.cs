using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    internal class ExcepcionColision : Exception
    {
        private static readonly string Mensaje = "Ha surgido una colisión al insertar.";
        public Cubeta CubetaColision { get; set; }
        public ExcepcionColision(Cubeta cubetaColision)
        : base(Mensaje)
        {
            this.CubetaColision = cubetaColision;
        }
    }
}
