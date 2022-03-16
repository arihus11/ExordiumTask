using Character.Utils;
public class EquipSlot : InventorySlot
{

    public EquipmentType EquipmentType;

    public override bool CanReceiveItem(Item item)
    {
        if (item == null)
        {
            return true;
        }
        EquipableItem equippableItem = item as EquipableItem;
        return equippableItem != null && equippableItem.EquipmentType == EquipmentType;
    }

}
