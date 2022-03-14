using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Create simple singleton pattern for Inventory recognition
    #region Singleton
    public static Inventory instance;


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

    public bool Add(Item item)
    {
        if (!item.notAddable)
        {
            if (items.Count >= emptySpace)
            {
                Debug.Log("Inventory is full!");
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


}
