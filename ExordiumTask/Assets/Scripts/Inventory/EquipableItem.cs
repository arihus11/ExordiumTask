
using UnityEngine;
using Character.Utils;

[CreateAssetMenu]
public class EquipableItem : Item
{
    public int StrengthBonus;
    public int AgilityBonus;
    public int IntelligenceBonus;
    public int VitalityBonus;
    [Space]
    public float StrengthPercentBonus;
    public float AgilityPercentBonus;
    public float IntelligencePercentBonus;
    public float VitalityPercentBonus;
    public EquipmentType EquipmentType;

    //Change attribute values here

    public bool Equip(InventoryManager x)
    {
        return true;
    }

    public bool Unequip(InventoryManager x)
    {
        return true;
    }
}
