// clase con funciones que permiten modoficar la cantidad de un mismo item dentro del inventario

[System.Serializable]
public class InventarioItems

{
    public InventarioItemDatos dato;
    public int tamañoInv;
    public InventarioItems(InventarioItemDatos itemDatos)
    {
        dato = itemDatos;
        AgregarItem();
    }
    public void AgregarItem()
    {
        tamañoInv++;
    }
    public void BorrarItem()
    {
        tamañoInv--;
    }
}
