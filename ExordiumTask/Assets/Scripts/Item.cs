﻿using UnityEngine;
using Character.Utils;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool notAddable = false;
    public UsageType useType;
    public SlotEquipType equipType;
    public bool stackable;
    public string stackLimit;

}
