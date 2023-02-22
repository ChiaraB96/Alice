// Personaje -> Inventario.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInventario : MonoBehaviour
{
    public static SistemaInventario Instancia;

    public delegate void cambioInventarioEvento();
    public event cambioInventarioEvento cambioInventarioLlamada;

    private Dictionary<InventarioItemDatos, InventarioItems> diccionarioItems;
    public List<InventarioItems> inventario;

    private void Awake()
    {
        //Inicializa lista de inventario y diccionario de items.
        inventario = new List<InventarioItems>(); 
        diccionarioItems = new Dictionary<InventarioItemDatos, InventarioItems>();

        Instancia = this;
    }

    public InventarioItems Get(InventarioItemDatos itemDatos) //Obtener un item con datos de inventario específicos.
    {
        
        if(diccionarioItems.TryGetValue(itemDatos, out InventarioItems value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventarioItemDatos itemDatos) //Agrega un objeto al inventario.
        {
            if(diccionarioItems.TryGetValue(itemDatos, out InventarioItems value))
            {
                value.AgregarItem();

                cambioInventarioLlamada.Invoke();
            }
            else
            {
                InventarioItems newItem = new InventarioItems(itemDatos);
                inventario.Add(newItem);
                diccionarioItems.Add(itemDatos, newItem);

                cambioInventarioLlamada.Invoke();
            }
        }
        public void Remove(InventarioItemDatos itemDatos, int cantidad) //Elimina un objeto del inventario.
        {
            if(diccionarioItems.TryGetValue(itemDatos, out InventarioItems value))
            {
                for(int i = 0; i < cantidad; i++)
                {
                    value.BorrarItem();
                }

                if(value.tamañoInv == 0)
                {
                    inventario.Remove(value);
                    diccionarioItems.Remove(itemDatos);
                }
            }

            cambioInventarioLlamada.Invoke();
        }
}
