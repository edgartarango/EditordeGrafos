using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    internal class Cubeta
    {
        public int direccion;
        private Cubeta siguienteCubeta;
        private int capacidad;
        private int registrosUtilizados;
        private List<Registro> registros;

        private CubetaG cubetaGrafica;

        public Cubeta(int capacidad, int direccion, Cubeta siguienteCubeta)
        {
            this.direccion = direccion;
            this.siguienteCubeta = siguienteCubeta;
            this.capacidad = capacidad;
            registros = new List<Registro>(capacidad);
            registrosUtilizados = 0;

            cubetaGrafica = new CubetaG(this.direccion, registrosUtilizados, this.capacidad);
        }
        public Cubeta(Registro registro, int capacidad, int direccion)
        {
            this.direccion = direccion;
            siguienteCubeta = null;
            this.capacidad = capacidad;
            registros = new List<Registro>(capacidad) { registro };
            registrosUtilizados = 1;

            cubetaGrafica = new CubetaG(this.direccion, registrosUtilizados, this.capacidad, registro.GetClave());
            cubetaGrafica.Registros[0] = registro.GetClave().ToString();
        }

        public Cubeta(int direccion, int capacidad)
        {
            this.direccion = direccion;
            siguienteCubeta = null;
            this.capacidad = capacidad;
            registros = new List<Registro>(capacidad);
            registrosUtilizados = 0;

            cubetaGrafica = new CubetaG(this.direccion, registrosUtilizados, this.capacidad);
        }

        public CubetaG GetCubetaG() { return cubetaGrafica; }
        public int GetRegistrosUtilizados() { return registrosUtilizados; }
        public List<Registro> GetRegistros() { return registros; }
        public Cubeta GetSiguiente() { return siguienteCubeta; }
        public int GetDireccion() { return direccion; }
        public List<CubetaG> GetCubetasG()
        {
            List<CubetaG> cubetasGraficas = new List<CubetaG>();
            for (Cubeta cubeta = this; cubeta != null; cubeta = cubeta.siguienteCubeta)
                cubetasGraficas.Add(cubeta.cubetaGrafica);
            return cubetasGraficas;
        }
        public void SetSiguiente(Cubeta siguienteCubeta)
        {
            this.siguienteCubeta = siguienteCubeta;
            if (siguienteCubeta != null)
                cubetaGrafica.APSiguienteCubeta = siguienteCubeta.direccion.ToString();
            else
                cubetaGrafica.APSiguienteCubeta = "null";
            cubetaGrafica.ActualizaCubeta();
        }

        private Cubeta BuscaCubeta(Registro registro, Cubeta padre, ref Cubeta anterior, ref Cubeta siguiente)
        {
            if (padre.registros.Find(r => r.GetClave() == registro.GetClave()) != null)
            {
                if (padre.siguienteCubeta != null)
                    siguiente = padre.siguienteCubeta;
                return padre;
            }
            else if (padre.siguienteCubeta != null)
            {
                anterior = padre;
                if (siguiente != null)
                    siguiente = siguiente.siguienteCubeta;
                return BuscaCubeta(registro, padre.siguienteCubeta, ref anterior, ref siguiente);
            }
            return padre;
        }
        private Cubeta BuscaCubetaInsercion(Registro registro, Cubeta padre)
        {
            if (padre.registros.Find(r => r.GetClave() > registro.GetClave()) != null)
                return padre;
            else if (padre.siguienteCubeta != null)
                return BuscaCubetaInsercion(registro, padre.siguienteCubeta);
            return padre;
        }
        public bool EliminaRegistro(Registro registro)
        {
            if (registros.Contains(registro))
            {
                registros.Remove(registro);
                registrosUtilizados--;
                cubetaGrafica.ActualizaRegistros(registros.Select(r => r.GetClave()).ToList());
                cubetaGrafica.ActualizaCubeta();
                return true;
            }
            return false;
        }

        public bool InsertaConColision(Registro registro, int EOF)
        {
            int posicion;
            Registro ultimo;
            posicion = registros.FindIndex(r => r.GetClave() > registro.GetClave());

            if (posicion >= 0 && posicion <= capacidad - 1)
            { 
                ultimo = registros.Last();
                registros.Remove(ultimo);
                registrosUtilizados--;
                try
                {
                    InsertaSimple(registro);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                ultimo = registro;

            if (siguienteCubeta != null)
            {
                try
                {
                    siguienteCubeta.InsertaSimple(ultimo);
                    return false;
                }
                catch (ExcepcionColision ex)
                {
                    return ex.CubetaColision.InsertaConColision(ultimo, EOF);
                }
            }
            else
            {
                siguienteCubeta = new Cubeta(ultimo, capacidad, EOF);
                cubetaGrafica.APSiguienteCubeta = siguienteCubeta.direccion.ToString();
                cubetaGrafica.ActualizaCubeta();
                return true;
            }
        }

        public void InsertaSimple(Registro registro)
        {
            int posicion;

            if (registrosUtilizados == capacidad)
                throw new ExcepcionColision(this);

            posicion = registros.FindIndex(r => r.GetClave() > registro.GetClave());
            if (posicion >= 0 && posicion <= capacidad - 1)
                registros.Insert(posicion, registro);
            else
                registros.Add(registro);

            cubetaGrafica.ActualizaRegistros(registros.Select(r => r.GetClave()).ToList());
            registrosUtilizados++;
            cubetaGrafica.ActualizaCubeta();
        }

        public void InsertaBusqueda(Registro registro)
        {
            int posicion;
            Cubeta cubetaDeInsercion;

            cubetaDeInsercion = BuscaCubetaInsercion(registro, this);

            if (cubetaDeInsercion != null)
            {
                if (cubetaDeInsercion.registrosUtilizados == capacidad)
                    throw new ExcepcionColision(cubetaDeInsercion);
                posicion = cubetaDeInsercion.registros.FindIndex(r => r.GetClave() > registro.GetClave());
                if (posicion >= 0 && posicion <= capacidad - 1)
                    registros.Insert(posicion, registro);
                else
                    registros.Add(registro);

                cubetaGrafica.ActualizaRegistros(registros.Select(r => r.GetClave()).ToList());
                registrosUtilizados++;
                cubetaGrafica.ActualizaCubeta();
            }
            else throw new NullReferenceException();
        }
    }
}
