
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipUi equipmentPanel;

    private void Awake()
    {
        inventory.OnItemRightClickEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickEvent += UnequipFromEquipPanel;
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
}
