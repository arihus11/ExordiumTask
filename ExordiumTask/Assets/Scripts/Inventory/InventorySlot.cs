using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    public GameObject icon;
    public Item item;

    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);
    public event Action<InventorySlot> OnRightClickEvent;
    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnPointerEnterEvent;
    public event Action<InventorySlot> OnPointerExitEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;
    public Button removeButton;
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.gameObject.GetComponent<SpriteRenderer>().sprite = item.icon;
        icon.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        removeButton.interactable = true;
        removeButton.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public virtual bool CanReceiveItem(Item item)
    {
        return true;
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
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            //   Debug.Log("RIGHT CLICK2");
            if (OnRightClickEvent != null)
            {
                //     Debug.Log("RIGHT CLICK3");
                OnRightClickEvent(this);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
        {
            OnPointerEnterEvent(this);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerExitEvent != null)
        {
            OnPointerExitEvent(this);
        }
    }
    Vector2 originalPosition;


    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = icon.transform.position;
        if (OnBeginDragEvent != null)
        {
            OnBeginDragEvent(this);

        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        icon.transform.position = originalPosition;
        if (OnEndDragEvent != null)
        {
            OnEndDragEvent(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        icon.transform.position = mousePosition;
        if (OnDragEvent != null)
        {
            OnDragEvent(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
        {
            OnDropEvent(this);
        }
    }

}
