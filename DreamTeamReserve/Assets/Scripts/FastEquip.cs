using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lol
{
    public class FastEquip : MonoBehaviour
    {
        [HideInInspector]
        public List<Item> item;
        public GameObject cellContainer;
        public PauseInGame OptionsObject;
        public GameObject player;

        void Start()
        {
            item = new List<Item>();

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

            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 3f))
                {
                    if (hit.collider.GetComponent<Item>())
                    {
                        Item currentItem = hit.collider.GetComponent<Item>();
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
}