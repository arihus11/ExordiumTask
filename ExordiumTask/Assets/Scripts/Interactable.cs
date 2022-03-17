using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Utils;

public class Interactable : MonoBehaviour
{
    private bool _isInRange = false;
    public bool destroyable;
    public static string itemInRange = "";
    public Item item;
    private Animator _usageText, _fullInventory;
    public bool thisItemInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        thisItemInRange = false;
        itemInRange = "";
        _usageText = GameObject.Find("UsageText").gameObject.GetComponent<Animator>();
        _fullInventory = GameObject.Find("NoMoreSpaceText").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInRange)
        {
            thisItemInRange = true;
            //Give permission to interact
            //  Debug.Log(itemInRange);
            if (PlayerController._hasInteracted)
            {
                if (destroyable == true && item.useType == UsageType.Pickup)
                {
                    Debug.Log("Picking up " + item.itemName);
                    PlayerController._hasInteracted = false;
                    bool wasPickedUp = Inventory.instance.Add(item);
                    if (wasPickedUp)
                    {
                        Destroy(this.gameObject);
                    }
                }
                else if (destroyable == true && item.useType == UsageType.PermanentUsage)
                {
                    Debug.Log("Consuming " + item.itemName);
                    PlayerController._hasInteracted = false;
                    Destroy(this.gameObject);
                }

                else
                {
                    Debug.Log("Interacting with " + item.itemName);
                    PlayerController._hasInteracted = false;
                }
            }

        }
        else
        {
            thisItemInRange = false;
        }

    }

    //Called when object is in range
    void inRange()
    {
        _isInRange = true;
        itemInRange = (this.gameObject.name).ToString();
        _usageText.Play("Interactable_Text", -1, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            notInRange();
        }
    }

    //Called when object is no longer in range
    void notInRange()
    {
        _isInRange = false;
        itemInRange = "";
        _usageText.Play("Idle_Message", -1, 0f);
        _fullInventory.Play("Idle_Message", -1, 0f);
    }
}
