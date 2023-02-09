using UnityEngine;

[CreateAssetMenu(fileName = "Inventario Item Datos", menuName = "Sistema Inventario/Crear Item")]
public class InventarioItemDatos : ScriptableObject
{
    public string id;
    public string nombre;
    public Sprite icono;
    public GameObject prefab;
}
