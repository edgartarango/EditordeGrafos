using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos
{
    internal class TablaDirecciones
    {
        public const int PUNTERO = 4;
        public const int AP_SIGUIENTE = 8;
        public readonly int TAM_CUBETA;
        public readonly int TAM_REGISTRO;
        private int numeroDeZocalos;
        private int capacidadCubetas;
        private int EOF;
        public List<Cubeta> direccionesDeCuebetas;
        private Stack<Cubeta> cubetasVacias;
        public TablaDirecciones(int numeroDeZocalos, int capacidadCubetas, int tamRegistro, int apVacias, int EOF)
        {
            this.numeroDeZocalos = numeroDeZocalos;
            this.capacidadCubetas = capacidadCubetas;
            this.EOF = EOF;
            TAM_REGISTRO = tamRegistro;
            TAM_CUBETA = AP_SIGUIENTE + PUNTERO + TAM_REGISTRO * capacidadCubetas;
            direccionesDeCuebetas = new List<Cubeta>(numeroDeZocalos);
            for (int zocalo = 0; zocalo < numeroDeZocalos; zocalo++)
                direccionesDeCuebetas.Add(null);
            cubetasVacias = new Stack<Cubeta>();
            if (apVacias != 0)
                cubetasVacias.Push(new Cubeta(apVacias, this.capacidadCubetas));
        }
        public TablaDirecciones(int numeroDeZocalos, int capacidadCubetas, int EOF, int tamRegistro)
        {
            this.numeroDeZocalos = numeroDeZocalos;
            this.capacidadCubetas = capacidadCubetas;
            this.EOF = EOF;
            TAM_REGISTRO = tamRegistro;
            TAM_CUBETA = AP_SIGUIENTE + PUNTERO + TAM_REGISTRO * capacidadCubetas;
            direccionesDeCuebetas = new List<Cubeta>(numeroDeZocalos);
            for (int zocalo = 0; zocalo < numeroDeZocalos; zocalo++)
                direccionesDeCuebetas.Add(null);
            cubetasVacias = new Stack<Cubeta>();
        }

        public List<Cubeta> GetDireccionesDeCubetas() { return direccionesDeCuebetas; }
        public void CargaCubetaVacias()
        {
        }
        public Stack<Cubeta> GetCubetasVacias() { return cubetasVacias; }
        public List<CubetaG> GetCubetasVaciasG()
        {
            return cubetasVacias.Select(c => c.GetCubetaG()).ToList();
        }
        public int GetApuntadorVacias()
        {
            if (cubetasVacias.Count > 0)
                return cubetasVacias.Peek().GetDireccion();
            else
                return 0;
        }
        public int GetNumeroDeZocalos() { return numeroDeZocalos; }
        public int GetCapacidadCubetas() { return capacidadCubetas; }
        public int GetEOF() { return EOF; }
        public int GetEOFInicial()
        {
            int menorDireccion = int.MaxValue;
            foreach (Cubeta zocalo in direccionesDeCuebetas)
                if (zocalo != null)
                    if (zocalo.GetDireccion() < menorDireccion)
                        menorDireccion = zocalo.GetDireccion();
            if (cubetasVacias.Count > 0)
                foreach (Cubeta cubeta in cubetasVacias)
                    if (cubeta.GetDireccion() < menorDireccion)
                        menorDireccion = cubeta.GetDireccion();
            if (menorDireccion == int.MaxValue) menorDireccion = EOF;
            return menorDireccion;
        }
        public int CuentaCubetas()
        {
            int cubetas = 0;

            for (int zocalo = 0; zocalo < direccionesDeCuebetas.Count; zocalo++)
            {
                Cubeta cubeta = direccionesDeCuebetas[zocalo];
                if (cubeta != null)
                {
                    cubetas++;
                    while (cubeta.GetSiguiente() != null)
                    {
                        cubeta = cubeta.GetSiguiente();
                        cubetas++;
                    }
                }
            }
            return cubetas;
        }
        public List<List<string>> TablaDireccionesComoTexto()
        {
            List<List<string>> tablaDirecciones = new List<List<string>>();

            for (int zocalo = 0; zocalo < direccionesDeCuebetas.Count; zocalo++)
            {
                if (direccionesDeCuebetas[zocalo] != null)
                    tablaDirecciones.Add(
                        new List<string>() {
                            zocalo.ToString(), direccionesDeCuebetas[zocalo].GetDireccion().ToString()
                        }
                    );
                else
                    tablaDirecciones.Add(
                        new List<string>() {
                            zocalo.ToString(), "null"
                        }
                    );
            }

            return tablaDirecciones;
        }
        public void SetZocalo(int zocalo, int direccion)
        {
            if (zocalo >= 0 && zocalo < direccionesDeCuebetas.Count)
                direccionesDeCuebetas[zocalo] = new Cubeta(direccion, capacidadCubetas);
            else
                throw new ExcepcionZocaloInvalido(zocalo);
        }
        public List<string> GeneraArchivo()
        {
            List<string> archivo = new List<string>();
            string linea;
            int localEOF;
            Cubeta cubeta;

            linea = String.Join(",", numeroDeZocalos, capacidadCubetas, TAM_REGISTRO, GetApuntadorVacias(), EOF) + ';';
            archivo.Add(linea);

            foreach (List<string> zocalo in TablaDireccionesComoTexto())
            {
                if (zocalo[1] != "null")
                    linea = String.Join(",", zocalo[0], zocalo[1]) + ';';
                else
                    linea = String.Join(",", zocalo[0], '0') + ';';
                archivo.Add(linea);
            }

            localEOF = GetEOFInicial();
            while (localEOF != EOF)
            {
                cubeta = BuscaCubeta(localEOF);
                if (cubeta != null)
                {
                    if (cubeta.GetSiguiente() != null)
                        linea = String.Join(",", cubeta.GetDireccion(), cubeta.GetRegistrosUtilizados(), cubeta.GetSiguiente().GetDireccion()) + ';';
                    else
                        linea = String.Join(",", cubeta.GetDireccion(), cubeta.GetRegistrosUtilizados(), '0') + ';';
                    archivo.Add(linea);
                    foreach (Registro registro in cubeta.GetRegistros())
                        archivo.Add(registro.GetClave().ToString() + ';');
                    localEOF += TAM_CUBETA;
                }
                else
                    throw new ExcepcionDireccionesYCubetas(localEOF);
            }

            return archivo;
        }

        public int ValidaDirecciones()
        {
            int localEOF;
            int errores;
            Cubeta cubeta;
            localEOF = GetEOFInicial();
            errores = 0;
            while (localEOF < EOF)
            {
                cubeta = BuscaCubeta(localEOF);
                if (cubeta == null)
                    errores++;
                localEOF += TAM_CUBETA;
            }
            return errores;
        }
        public Cubeta BuscaCubeta(int direccion)
        {
            Cubeta cubeta;
            for (int zocalo = 0; zocalo < direccionesDeCuebetas.Count; zocalo++)
            {
                cubeta = direccionesDeCuebetas[zocalo];
                if (cubeta != null)
                {
                    if (cubeta.GetDireccion() == direccion)
                        return cubeta;
                    else
                        while (cubeta.GetSiguiente() != null)
                        {
                            cubeta = cubeta.GetSiguiente();
                            if (cubeta.GetDireccion() == direccion)
                                return cubeta;
                        }
                }
            }
            if (cubetasVacias.Count > 0)
            {
                cubeta = cubetasVacias.ToList().Find(c => c.GetDireccion() == direccion);
                if (cubeta != null)
                    return cubeta;
            }
            return null;
        }

        public bool ExisteClave(int clave)
        {
            for (int zocalo = 0; zocalo < direccionesDeCuebetas.Count; zocalo++)
            {
                Cubeta cubeta = direccionesDeCuebetas[zocalo];
                if (cubeta != null)
                {
                    if (cubeta.GetRegistros().Find(r => r.GetClave() == clave) != null)
                        return true;
                    else
                        while (cubeta.GetSiguiente() != null)
                        {
                            cubeta = cubeta.GetSiguiente();
                            if (cubeta.GetRegistros().Find(r => r.GetClave() == clave) != null)
                                return true;
                        }
                }
            }
            return false;
        }
        public bool Elimina(int clave)
        {
            if (!ExisteClave(clave))
                return false;

            int posicion = HashMod(clave);
            Cubeta zocalo = direccionesDeCuebetas[posicion];

            if (zocalo != null)
            {
                // Check if the key is in the head cubeta
                Registro registroAEliminar = zocalo.GetRegistros().Find(r => r.GetClave() == clave);
                if (registroAEliminar != null)
                {
                    return zocalo.EliminaRegistro(registroAEliminar);
                }
                else
                {
                    // Check the chain of cubetas
                    Cubeta cubetaActual = zocalo;
                    while (cubetaActual.GetSiguiente() != null)
                    {
                        cubetaActual = cubetaActual.GetSiguiente();
                        registroAEliminar = cubetaActual.GetRegistros().Find(r => r.GetClave() == clave);
                        if (registroAEliminar != null)
                        {
                            return cubetaActual.EliminaRegistro(registroAEliminar);
                        }
                    }
                }
            }

            return false;
        }

        public int HashMod(int clave)
        {
            int posicion;

            posicion = clave % numeroDeZocalos;

            if (posicion >= 0 && posicion < numeroDeZocalos)
                return posicion;
            else
                return -1;
        }

        public void Inserta(int clave)
        {
            int posicion;
            Cubeta zocaloDeInsercion;

            if (ExisteClave(clave))
                throw new ExcepcionClaveExistente(clave);

            posicion = HashMod(clave);
            if (posicion != -1)
            {
                zocaloDeInsercion = direccionesDeCuebetas[posicion];

                if (zocaloDeInsercion != null)
                {
                    try
                    {
                        zocaloDeInsercion.InsertaBusqueda(new Registro(clave));
                    }
                    catch (ExcepcionColision ex)
                    {
                        if (ex.CubetaColision.InsertaConColision(new Registro(clave), EOF))
                            EOF += TAM_CUBETA;
                    }
                }
                else
                {
                    direccionesDeCuebetas[posicion] = new Cubeta(new Registro(clave), capacidadCubetas, EOF);
                    EOF += TAM_CUBETA;
                }
            }
        }
    }
}