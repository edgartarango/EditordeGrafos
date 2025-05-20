using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    class ExcepcionClaveExistente : Exception
    {
        private static readonly string Mensaje = "La clave ya existe en la tabla.";
        public int ClaveExistente { get; set; }
        public ExcepcionClaveExistente(int claveExistente)
        : base(Mensaje)
        {
            this.ClaveExistente = claveExistente;
        }
    }
}
