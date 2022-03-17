using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

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
    private Animator _notStackable;
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
        _notStackable = GameObject.Find("NotStackable").gameObject.GetComponent<Animator>();
    }
    public bool Add(Item item)
    {
        if (!item.notAddable)
        {
            if (item.stackable)
            {
                if (items.Count >= emptySpace)
                {
                    Debug.LogWarning("Inventory is full!");
                    DisplayMessage();
                    return false;
                }
                else
                {
                    for (int i = 0; i < itemSlots.Length; i++)
                    {
                        if (itemSlots[i].item == item)
                        {
                            Debug.Log("Item alredy exists!");
                            itemSlots[i].stackCounter.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = (int.Parse(itemSlots[i].stackCounter.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text) + 1).ToString();
                            return true;
                        }

                    }
                    items.Add(item);
                    if (onItemChangedCallback != null)
                    {
                        onItemChangedCallback.Invoke();
                    }
                    return true;
                }
            }
            else
            {
                for (int i = 0; i < itemSlots.Length; i++)
                {
                    if (itemSlots[i].item == item)
                    {
                        _notStackable.Play("Interactable_Text", -1, 0f);
                        Invoke("ChangeText", 0.7f);
                        return false;
                    }
                }
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
        }
        return false;
    }

    public void ChangeText()
    {
        _notStackable.Play("Idle_Message", -1, 0f);
    }
    public bool Remove(Item item)
    {
        if (item.stackable)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].item == item)
                {
                    if ((int.Parse(itemSlots[i].stackCounter.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text) > 1))
                    {
                        itemSlots[i].stackCounter.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = (int.Parse(itemSlots[i].stackCounter.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text) - 1).ToString();
                        return true;
                    }
                    else
                    {
                        itemSlots[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        items.Remove(item);
                        if (onItemChangedCallback != null)
                        {
                            onItemChangedCallback.Invoke();
                        }
                        return true;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].item == item)
                {
                    itemSlots[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
