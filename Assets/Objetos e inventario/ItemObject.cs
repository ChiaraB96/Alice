using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickUpItem()
    {
        InventorySystemm.Instance.Add(referenceItem);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            OnHandlePickUpItem();
        }
    }
}
