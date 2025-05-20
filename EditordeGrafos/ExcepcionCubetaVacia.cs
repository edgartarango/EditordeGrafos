using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    class ExcepcionCubetaVacia : Exception
    {
        private static readonly string Mensaje = "Una cubeta quedó vacía.";
        public Cubeta CubetaVacia { get; set; }
        public Cubeta CubetaAnterior { get; set; }
        public Cubeta CubetaSiguiente { get; set; }

        public ExcepcionCubetaVacia(Cubeta cubetaVacia, Cubeta cubetaAnterior, Cubeta cubetaSiguiente)
        : base(Mensaje)
        {
            this.CubetaVacia = cubetaVacia;
            this.CubetaAnterior = cubetaAnterior;
            this.CubetaSiguiente = cubetaSiguiente;
        }
    }
}
