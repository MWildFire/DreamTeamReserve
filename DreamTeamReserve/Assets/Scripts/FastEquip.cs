using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastEquip : MonoBehaviour
{
    [HideInInspector]
    public List<Item> item;
    public GameObject cellContainer;
    public GameObject BG_Panel;
    public GameObject player;

    void Start()
    {
        item = new List<Item>();

        cellContainer.SetActive(false);
        BG_Panel.SetActive(false);

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
        }

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
        }
    }

    void Update()
    {
        ToggleInventory();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2.5f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    Item currentItem = hit.collider.GetComponent<Item>();
                    Message(currentItem);
                    AddItem(hit.collider.GetComponent<Item>());
                }
            }
        }
    }

    void AddItem(Item currentItem)
    {
        if (currentItem.isStackable)
        {
            AddStackableItem(currentItem);
        }
        else
        {
            AddUnstackableItem(currentItem);
        }
    }

    void AddUnstackableItem(Item currentItem)
    {

        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == 0)
            {
                item[i] = currentItem;
                item[i].countItem = 1;
                DisplayItems();
                Destroy(currentItem.gameObject);
                break;
            }
        }
    }

    void AddStackableItem(Item currentItem)
    {

        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == currentItem.id)
            {
                item[i].countItem++;
                DisplayItems();
                Destroy(currentItem.gameObject);
                return;
            }
        }
        AddUnstackableItem(currentItem);
    }

    void ToggleInventory()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {

            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
                BG_Panel.SetActive(false);
                //Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.GetComponent<Player_Controller>().enabled = true;
                //Cross.SetActive(true);
            }
            else
            {
                cellContainer.SetActive(true);
                BG_Panel.SetActive(true);
                //Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.GetComponent<Player_Controller>().enabled = false;
                //Cross.SetActive(false);
            }
        }

    }

    public void DisplayItems()
    {
        for (int i = 0; i < item.Count; i++)
        {

            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform count = icon.GetChild(0);

            Text txt = count.GetComponent<Text>();
            Image img = icon.GetComponent<Image>();

            if (item[i].id != 0)
            {
                img.enabled = true;
                img.sprite = Resources.Load<Sprite>(item[i].pathIcon);
                if (item[i].countItem > 1)
                {
                    txt.text = item[i].countItem.ToString();
                }
                else
                {
                    txt.text = null;
                }
            }

            else
            {
                img.enabled = false;
                img.sprite = null;
                txt.text = null;
            }
        }
    }
}
