using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item Data", menuName = "Inventory System/Create Item")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
}
