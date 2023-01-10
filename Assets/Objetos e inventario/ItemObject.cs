using UnityEngine;
using UnityEngine.Events;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData itemData;
    public UnityEvent OnPickUp; 

    public void HandlePickUp()
    {
        InventorySystem.Instance.Add(itemData);
        OnPickUp.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            HandlePickUp();
        }
    }
}