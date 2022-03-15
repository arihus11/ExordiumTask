using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Create simple singleton pattern for Inventory recognition
    #region Singleton
    public static Inventory instance;
    private Animator _usageText, _fullInventory;


    void Awake()
    {
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

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    void DisplayMessage()
    {

        _usageText.Play("Idle_Message", -1, 0f);
        _fullInventory.Play("Interactable_Text", -1, 0f);

    }


}
