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
