using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public Image _itemIcon;

    public GameObject _stackObj;

    public TextMeshProUGUI _stackNumber;

    public void Set(InventoryItem item)
    {
        _itemIcon.sprite = item.data.itemIcon;

        if (item.stackSize <= 1)
        {
            _stackObj.SetActive(false);
            return;
        }

        _stackNumber.text = item.stackSize.ToString();
    }
    public void Reset()
    {
        _itemIcon.sprite = null;
        _stackObj.SetActive(false);
        _stackNumber.text = "";
    }
}