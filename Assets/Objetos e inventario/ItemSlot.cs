using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private GameObject _stackObj;

    [SerializeField]
    private TextMeshProUGUI _stackNumber;

    public void Set(InventoryItem item)
    {
        if (item == null || item.data == null || item.data.itemIcon == null)
        {
            Debug.LogError("Item or Item Data or Item Icon is not set");
            return;
        }
        _itemIcon.sprite = item.data.itemIcon;

        if (item.stackSize <= 1)
        {
            _stackObj.SetActive(false);
            return;
        }

        _stackNumber.text = item.stackSize.ToString();
    }
}