using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    //Create simple singleton pattern for Inventory recognition
    #region Singleton
    public static Inventory instance;
    private Animator _usageText, _fullInventory;
    [SerializeField] InventorySlot[] itemSlots;

    public event Action<InventorySlot> OnRightClickEvent;
    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnPointerEnterEvent;
    public event Action<InventorySlot> OnPointerExitEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;
    private void Awake()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;
        }

        if (instance != null)
        {
            Debug.LogWarning(("More than on inventory exists!"));
            return;
        }
        instance = this;
    }

    #endregion
    public List<Item> items = new List<Item>();

    //Create delegate (event that you can subscribe different methods to)
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int emptySpace = 40;

    void Start()
    {
        _usageText = GameObject.Find("UsageText").gameObject.GetComponent<Animator>();
        _fullInventory = GameObject.Find("NoMoreSpaceText").gameObject.GetComponent<Animator>();
    }
    public bool Add(Item item)
    {
        if (!item.notAddable)
        {
            if (items.Count >= emptySpace)
            {
                Debug.LogWarning("Inventory is full!");
                DisplayMessage();
                return false;
            }
            else
            {
                items.Add(item);
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            }
        }
        return false;
    }

    public bool Remove(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == item)
            {
                items.Remove(item);
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                return false;
            }
        }
        return true;
    }

    void DisplayMessage()
    {

        _usageText.Play("Idle_Message", -1, 0f);
        _fullInventory.Play("Interactable_Text", -1, 0f);

    }


}
