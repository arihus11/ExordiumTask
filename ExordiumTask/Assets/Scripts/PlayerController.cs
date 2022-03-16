using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool _hasInteracted = false;
    public Transform transformParent;
    public GameObject[] objectSpawn;
    private bool _oneSpawn = false;
    private int _randomSide, _randomNumber, _lastRandom, _itemPosition;

    private Vector3 _spawnVector;

    // Start is called before the first frame update
    void Start()
    {
        _oneSpawn = false;
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
    }

    void ClaculateRandomPosition()
    {
        _randomNumber = Random.Range(0, objectSpawn.Length);
        _randomSide = RandomRangeExcept(0, 6, _lastRandom);
        _lastRandom = _randomSide;
        #region Switch
        switch (_randomSide)
        {
            case 0:
                _spawnVector = this.gameObject.transform.position + new Vector3(0, 1, 0);
                break;
            case 1:
                _spawnVector = this.gameObject.transform.position - new Vector3(0, 1, 0);
                break;
            case 2:
                _spawnVector = this.gameObject.transform.position + new Vector3(1, 0, 0);
                break;
            case 3:
                _spawnVector = this.gameObject.transform.position - new Vector3(1, 0, 0);
                break;
            case 4:
                _spawnVector = this.gameObject.transform.position + new Vector3(1, 1, 0);
                break;
            case 5:
                _spawnVector = this.gameObject.transform.position - new Vector3(1, 1, 0);
                break;
            default:
                break;
        }
        #endregion
    }


    public int RandomRangeExcept(int min, int max, int except)
    {
        int number;
        do
        {
            number = Random.Range(min, max);
        } while (number == except);
        return number;
    }



}
