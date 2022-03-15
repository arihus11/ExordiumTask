using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{

    public GameObject icon;
    Item item;

    public void EquipItem(Item newItem)
    {
        item = newItem;

        icon.gameObject.GetComponent<SpriteRenderer>().sprite = item.icon;
        icon.gameObject.GetComponent<SpriteRenderer>().enabled = true;

    }

    public void UnequipItem()
    {
        item = null;

        icon.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        icon.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
