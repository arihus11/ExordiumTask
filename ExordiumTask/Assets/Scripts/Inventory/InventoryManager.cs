
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipUi equipmentPanel;
    [SerializeField] Image draggableItem;

    private InventorySlot draggedSlot;

    private void Awake()
    {
        //RightClick
        inventory.OnRightClickEvent += Equip;
        equipmentPanel.OnRightClickEvent += Unequip;
        //BeginDrag
        inventory.OnBeginDragEvent += BeginDrag;
        equipmentPanel.OnBeginDragEvent += BeginDrag;
        //EndDrag 
        inventory.OnEndDragEvent += EndDrag;
        equipmentPanel.OnEndDragEvent += EndDrag;
        //Drag
        inventory.OnDragEvent += Drag;
        equipmentPanel.OnDragEvent += Drag;
        //Drop
        inventory.OnDropEvent += Drop;
        equipmentPanel.OnDropEvent += Drop;
    }

    private void Equip(InventorySlot itemSlot)
    {
        EquipableItem equippableItem = itemSlot.item as EquipableItem;
        if (equippableItem != null)
        {
            Equip(equippableItem);
        }
    }

    private void Unequip(InventorySlot itemSlot)
    {
        EquipableItem equippableItem = itemSlot.item as EquipableItem;
        if (equippableItem != null)
        {
            Unequip(equippableItem);
        }
    }

    private void EquipFromInventory(Item item)
    {
        if (item is EquipableItem)
        {
            Equip((EquipableItem)item);
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if (item is EquipableItem)
        {
            Unequip((EquipableItem)item);
        }
    }
    public void Equip(EquipableItem item)
    {
        if (inventory.Remove(item))
        {
            EquipableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.Add(previousItem);
                }
            }
            else
            {
                inventory.Add(item);
            }
        }
    }

    public void Unequip(EquipableItem item)
    {
        if (equipmentPanel.RemoveItem(item))
        {
            inventory.Add(item);
        }
    }

    private void BeginDrag(InventorySlot itemSlot)
    {
        if (itemSlot.item != null)
        {
            Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.item.icon;
            draggableItem.transform.position = mousePosition;
            draggableItem.enabled = true;
        }
    }
    private void EndDrag(InventorySlot itemSlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }
    private void Drag(InventorySlot itemSlot)
    {
        Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = mousePosition;
        }

    }
    private void Drop(InventorySlot dropItemSlot)
    {
        if (dropItemSlot.CanReceiveItem(draggedSlot.item) && draggedSlot.CanReceiveItem(dropItemSlot.item))
        {
            EquipableItem dragItem = draggedSlot.item as EquipableItem;
            EquipableItem dropItem = dropItemSlot.item as EquipableItem;

            if (draggedSlot is EquipSlot)
            {
                if (dragItem != null) dragItem.Unequip(this);
                if (dropItem != null) dropItem.Equip(this);
            }

            if (dropItemSlot is EquipSlot)
            {
                if (dragItem != null) dragItem.Equip(this);
                if (dropItem != null) dropItem.Unequip(this);
            }

            Item draggedItem = draggedSlot.item;
            draggedSlot.item = dropItemSlot.item;
            dropItemSlot.item = draggedItem;
        }

    }


}
