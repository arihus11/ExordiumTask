using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipUi : MonoBehaviour
{

    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipSlot[] equipmentSlots;
    public GameObject equipUI;
    public event Action<Item> OnItemRightClickEvent;
    void Awake()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnItemRightClickEvent;
        }
    }
    void Start()
    {

    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EquipPanel"))
        {
            equipUI.SetActive(!equipUI.activeSelf);
        }
    }

    public bool AddItem(EquipableItem item, out EquipableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquipableItem)equipmentSlots[i].item;
                equipmentSlots[i].item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquipableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].item == item)
            {
                equipmentSlots[i].item = null;
                return true;
            }
        }
        return false;
    }
}
