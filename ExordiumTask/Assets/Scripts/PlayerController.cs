using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool _hasInteracted = false;
<<<<<<< HEAD
    public Transform transformParent;
    public GameObject[] objectSpawn;
    private bool _oneSpawn = false;
    private int _closePanels = 0;
    public GameObject[] inventories;
    private int _randomSide, _randomNumber, _lastRandom, _itemPosition;

    private Vector3 _spawnVector;
=======
>>>>>>> parent of c40d3de (Create object spawning for discarded items)

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        _oneSpawn = false;
        _closePanels = 0;
=======

>>>>>>> parent of c40d3de (Create object spawning for discarded items)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Interactable.itemInRange != "")
            {
                _hasInteracted = true;
            }
        }
<<<<<<< HEAD
        else if (Input.GetKey(KeyCode.Tab))
        {
            if (!_oneSpawn)
            {
                _oneSpawn = true;
                _closePanels++;
                Invoke("ChangeSwitch", 0.2f);
            }
            if (_closePanels == 1)
            {
                for (int i = 0; i < inventories.Length; i++)
                {
                    inventories[i].SetActive(true);
                }
            }
            else if (_closePanels == 2)
            {
                _closePanels = 0;
                for (int i = 0; i < inventories.Length; i++)
                {
                    inventories[i].SetActive(false);
                }
            }

        }
        else if (Input.GetKey(KeyCode.Space) || InventorySlot.spawnNewItem == true)
        {
            if (InventorySlot.spawnNewItem)
            {
                InventorySlot.spawnNewItem = false;
                for (int i = 0; i < objectSpawn.Length; i++)
                {
                    if (objectSpawn[i].gameObject.name == InventorySlot.removedItemName)
                    {
                        _itemPosition = i;
                        break;
                    }
                }
                if (!_oneSpawn)
                {
                    _oneSpawn = true;
                    ClaculateRandomPosition();
                    Instantiate(objectSpawn[_itemPosition], _spawnVector, Quaternion.identity, transformParent);
                    Invoke("ChangeSwitch", 0.2f);
                }

            }
            else
            {
                if (!_oneSpawn)
                {
                    _oneSpawn = true;
                    ClaculateRandomPosition();
                    Instantiate(objectSpawn[_randomNumber], _spawnVector, Quaternion.identity, transformParent);
                    Invoke("ChangeSwitch", 0.2f);
                }
            }
        }
    }

    void ChangeSwitch()
    {
        _oneSpawn = false;
=======
>>>>>>> parent of c40d3de (Create object spawning for discarded items)
    }
}
