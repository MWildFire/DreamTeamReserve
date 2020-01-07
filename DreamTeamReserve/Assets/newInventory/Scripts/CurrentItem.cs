using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentItem : MonoBehaviour, IPointerClickHandler
{

    [HideInInspector]
    public int index;

    GameObject inventoryObj;
    Inventory inventory;

    void Start()
    {
        inventoryObj = GameObject.FindGameObjectWithTag("InventoryManager");
        inventory = inventoryObj.GetComponent<Inventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (inventory.item[index].customEvent != null)
            {
                inventory.item[index].customEvent.Invoke();
            }

            if (inventory.item[index].isRemovable)
            {
                Remove();
            }
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Drop();
            Remove();
        }

    }

    void Drop()
    {
        if (inventory.item[index].id != 0)
        {
            GameObject droppedObj = Instantiate(Resources.Load<GameObject>(inventory.item[index].pathPrefab));
            droppedObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
        }
    }

    void Remove()
    {
        if(inventory.item[index].id != 0)
        {
            if(inventory.item[index].countItem > 1)
            {
                inventory.item[index].countItem--;
            }
            else
            {
                inventory.item[index] = new Item();
            }
            inventory.DisplayItems();
        }
    }
}
