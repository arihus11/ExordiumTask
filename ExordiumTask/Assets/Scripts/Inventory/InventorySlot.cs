using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject icon;
    Item item;
    public Button removeButton;
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.gameObject.GetComponent<SpriteRenderer>().sprite = item.icon;
        icon.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        removeButton.interactable = true;
        removeButton.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;

        icon.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        icon.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        removeButton.interactable = false;
        removeButton.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
