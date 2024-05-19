using ArbolBinario.Models;
using System.Collections.Generic;

namespace ArbolBinario.Services
{
    internal class ArbolBinarioService
    {
        public NodoArbol? NodoRaiz { get; set; }
        public string Respuesta { get; set; } = string.Empty;

        public ArbolBinarioService()
        {
            NodoRaiz = null;
        }

        bool EstaVacio()
        {
            return NodoRaiz == null;
        }

        public NodoArbol CrearNodo(string info)
        {
            return new NodoArbol(info);
        }

        public void PoblarArbol(NodoArbol nodo, string infoIzquierdo, string infoDerecho)
        {
            if (EstaVacio())
            {
                NodoRaiz = nodo;
            }

            if (!string.IsNullOrEmpty(infoIzquierdo))
            {
                nodo.RamaIzquierda = CrearNodo(infoIzquierdo);
            }

            if (!string.IsNullOrEmpty(infoDerecho))
            {
                nodo.RamaDerecha = CrearNodo(infoDerecho);
            }
        }

        public void RecorridoPreorden(NodoArbol nodo, List<string> recorrido)
        {
            if (nodo == null) return;

            recorrido.Add(nodo.Informacion);
            RecorridoPreorden(nodo.RamaIzquierda, recorrido);
            RecorridoPreorden(nodo.RamaDerecha, recorrido);
        }

        public void RecorridoInorden(NodoArbol nodo, List<string> recorrido)
        {
            if (nodo == null) return;

            RecorridoInorden(nodo.RamaIzquierda, recorrido);
            recorrido.Add(nodo.Informacion);
            RecorridoInorden(nodo.RamaDerecha, recorrido);
        }

        public void RecorridoPostorden(NodoArbol nodo, List<string> recorrido)
        {
            if (nodo == null) return;

            RecorridoPostorden(nodo.RamaIzquierda, recorrido);
            RecorridoPostorden(nodo.RamaDerecha, recorrido);
            recorrido.Add(nodo.Informacion);
        }

        public void RecorridoInordenIterativo(NodoArbol nodo, List<string> recorrido)
        {
            NodoArbol? actual = nodo;

            while (actual != null)
            {
                if (actual.RamaIzquierda == null)
                {
                    recorrido.Add(actual.Informacion);
                    actual = actual.RamaDerecha;
                }
                else
                {
                    NodoArbol predecesor = actual.RamaIzquierda;
                    while (predecesor.RamaDerecha != null && predecesor.RamaDerecha != actual)
                    {
                        predecesor = predecesor.RamaDerecha;
                    }

                    if (predecesor.RamaDerecha == null)
                    {
                        predecesor.RamaDerecha = actual;
                        actual = actual.RamaIzquierda;
                    }
                    else
                    {
                        predecesor.RamaDerecha = null;
                        recorrido.Add(actual.Informacion);
                        actual = actual.RamaDerecha;
                    }
                }
            }
        }

        public void RecorridoPreordenIterativo(NodoArbol nodo, List<string> recorrido)
        {
            NodoArbol? actual = nodo;

            while (actual != null)
            {
                if (actual.RamaIzquierda == null)
                {
                    recorrido.Add(actual.Informacion);
                    actual = actual.RamaDerecha;
                }
                else
                {
                    NodoArbol predecesor = actual.RamaIzquierda;
                    while (predecesor.RamaDerecha != null && predecesor.RamaDerecha != actual)
                    {
                        predecesor = predecesor.RamaDerecha;
                    }

                    if (predecesor.RamaDerecha == null)
                    {
                        predecesor.RamaDerecha = actual;
                        recorrido.Add(actual.Informacion);
                        actual = actual.RamaIzquierda;
                    }
                    else
                    {
                        predecesor.RamaDerecha = null;
                        actual = actual.RamaDerecha;
                    }
                }
            }
        }

        public void RecorridoPostordenIterativo(NodoArbol nodo, List<string> recorrido)
        {
            NodoArbol nodoTemporal = new NodoArbol { RamaIzquierda = nodo };
            NodoArbol? actual = nodoTemporal;

            while (actual != null)
            {
                if (actual.RamaIzquierda == null)
                {
                    actual = actual.RamaDerecha;
                }
                else
                {
                    NodoArbol predecesor = actual.RamaIzquierda;
                    while (predecesor.RamaDerecha != null && predecesor.RamaDerecha != actual)
                    {
                        predecesor = predecesor.RamaDerecha;
                    }

                    if (predecesor.RamaDerecha == null)
                    {
                        predecesor.RamaDerecha = actual;
                        actual = actual.RamaIzquierda;
                    }
                    else
                    {
                        AddNodesReverse(actual.RamaIzquierda, predecesor, recorrido);
                        predecesor.RamaDerecha = null;
                        actual = actual.RamaDerecha;
                    }
                }
            }
        }

        private void AddNodesReverse(NodoArbol from, NodoArbol to, List<string> recorrido)
        {
            List<string> temp = new List<string>();
            NodoArbol? current = from;
            while (current != to)
            {
                temp.Add(current.Informacion);
                current = current.RamaDerecha;
            }
            temp.Add(to.Informacion);
            temp.Reverse();
            recorrido.AddRange(temp);
        }

        public void EliminarNodo(string info)
        {
            NodoRaiz = EliminarNodo(NodoRaiz, info);
        }

        private NodoArbol? EliminarNodo(NodoArbol? nodo, string info)
        {
            if (nodo == null) return null;

            if (info.CompareTo(nodo.Informacion) < 0)
            {
                nodo.RamaIzquierda = EliminarNodo(nodo.RamaIzquierda, info);
            }
            else if (info.CompareTo(nodo.Informacion) > 0)
            {
                nodo.RamaDerecha = EliminarNodo(nodo.RamaDerecha, info);
            }
            else
            {
                // Nodo encontrado
                if (nodo.RamaIzquierda == null)
                {
                    return nodo.RamaDerecha;
                }
                else if (nodo.RamaDerecha == null)
                {
                    return nodo.RamaIzquierda;
                }
                else
                {
                    NodoArbol sucesor = EncontrarMinimo(nodo.RamaDerecha);
                    nodo.Informacion = sucesor.Informacion;
                    nodo.RamaDerecha = EliminarNodo(nodo.RamaDerecha, sucesor.Informacion);
                }
            }
            return nodo;
        }

        private NodoArbol EncontrarMinimo(NodoArbol nodo)
        {
            while (nodo.RamaIzquierda != null)
            {
                nodo = nodo.RamaIzquierda;
            }
            return nodo;
        }
    }
}
