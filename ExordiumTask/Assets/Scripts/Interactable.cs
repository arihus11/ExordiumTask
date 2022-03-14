using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool _isInRange = false;
    public bool destroyable;
    public static string itemInRange = "";
    // Start is called before the first frame update
    void Start()
    {
        itemInRange = "";
    }

    public virtual void Interact()
    {
        //Override method on interaction
        Debug.Log("Do something.");
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInRange)
        {
            //Give permission to interact
            //  Debug.Log(itemInRange);
            if (PlayerController._hasInteracted && destroyable == true)
            {
                PlayerController._hasInteracted = false;
                Destroy(this.gameObject);
            }
        }

    }

    //Called when object is in range
    void inRange()
    {
        _isInRange = true;
        itemInRange = (this.gameObject.name).ToString();
        GameObject.Find("UsageText").gameObject.GetComponent<Animator>().Play("Interactable_Text", -1, 0f);
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
        GameObject.Find("UsageText").gameObject.GetComponent<Animator>().Play("Interactable_Text_Reverse", -1, 0f);
    }
}
