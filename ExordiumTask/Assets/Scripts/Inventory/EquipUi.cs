using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipUi : MonoBehaviour
{
    //  Inventory inventory;
    //   public Transform itemsParent;

    public GameObject equipUI;
    // EquipSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EquipPanel"))
        {
            equipUI.SetActive(!equipUI.activeSelf);
        }
    }

    void UpdateUI()
    {

    }
}
