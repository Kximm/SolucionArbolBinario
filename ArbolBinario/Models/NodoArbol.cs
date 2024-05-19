using System.Timers;

namespace ArbolBinario.Models
{
    public class NodoArbol
    {
        public NodoArbol? RamaIzquierda { get; set; }
        public NodoArbol? RamaDerecha { get; set; }
        public string Informacion { get; set; }

        public NodoArbol()
        {
            RamaIzquierda = null;
            RamaDerecha = null;
            Informacion = null;
        }

        public NodoArbol(string info)
        {
            Informacion = info;
            RamaIzquierda = null;
            RamaDerecha = null;
        }

        public NodoArbol(NodoArbol? ramaIzquierda, NodoArbol? ramaDerecha, string? informacion)
        {
            RamaIzquierda = ramaIzquierda;
            RamaDerecha = ramaDerecha;
            Informacion = informacion;
        }

        public override string ToString()
        {
            return $"/{Informacion}\\";
        }
    }
}
