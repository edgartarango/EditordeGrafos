using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{

    public class Leaf
    {
        public long Direccion;
        public char Tipo;
        public long GradoHoja;


        public List<long> list_Content;

        public List<long> list_Dir;



        public int aux_Cuenta;



        public Leaf()
        { }

        public Leaf(int Grade)
        {


            list_Dir = new List<long>();
            list_Content = new List<long>();

            GradoHoja = Grade;

        }
    }


}
