using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject icon;
    public Item item;
    public event Action<Item> OnRightClickEvent;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("RIGHT CLICK2");
            if (item != null && OnRightClickEvent != null)
            {
                Debug.Log("RIGHT CLICK3");
                OnRightClickEvent(item);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
    public void OnPointerDrag(PointerEventData eventData)
    {

    }
    Vector2 originalPosition;


    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = icon.transform.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        icon.transform.position = originalPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        icon.transform.position = Input.mousePosition;
    }

}
