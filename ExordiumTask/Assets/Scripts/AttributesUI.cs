using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesUI : MonoBehaviour
{

    public GameObject attributesUI;
    public GameObject equipUI;
    public GameObject invUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attributes"))
        {
            attributesUI.SetActive(!attributesUI.activeSelf);
        }
    }
}
