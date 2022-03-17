using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGlow : MonoBehaviour
{
    public static ItemGlow instance;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Interactable>().thisItemInRange)
        {
            EnableGlow();
        }
        else
        {
            DisableGlow();
        }
    }
    void OnMouseEnter()
    {
        EnableGlow();
    }
    void OnMouseExit()
    {
        DisableGlow();
    }

    public void EnableGlow()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void DisableGlow()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
