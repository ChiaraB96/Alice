[System.Serializable]
public class InventoryItem

{
    public InventoryItemData data;
    public int stackSize;
    public InventoryItem(InventoryItemData itemData)
    {
        data = itemData;
        AddToStack();
    }
    public void AddToStack()
    {
        stackSize++;
    }
    public void RemoveFromStack()
    {
        stackSize--;
    }
}
