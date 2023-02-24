/* Personaje -> HudBar -> Imagen.

    Actualiza la interfaz del inventario cada vez que el mismo se modifique
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazInventario : MonoBehaviour
{
    public GameObject prefabSlot; // prefab del slot

    private void Start()
    {
        SistemaInventario.Instancia.cambioInventarioLlamada += actualizarInventario;
    }

    public void actualizarInventario()
    {
        foreach (Transform objeto in transform)
        {
            Destroy(objeto.transform.gameObject);            
        }

        crearInventario();
    }

    public void crearInventario()
    {
        foreach(InventarioItems item in SistemaInventario.Instancia.inventario)
        {
            agregarSlot(item);
        }
    }
    
   public void agregarSlot(InventarioItems item)
   {
    GameObject obj = Instantiate(prefabSlot);
    obj.transform.SetParent(transform, false);
    ItemSlot slot = obj.GetComponent<ItemSlot>();
    slot.Set(item);
   }
}
