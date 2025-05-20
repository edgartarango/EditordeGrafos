using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    public class Tree_BMas
    {
        public string Tipo;
        public long Direccion;
        public long Num;
        public long Direccion_Next;


        public Tree_BMas()
        { }



        public Tree_BMas(int Content)
        {


            Direccion_Next = -1;
            Tipo = "\t ...  ";

            Num = Content;


        }
    }


}
