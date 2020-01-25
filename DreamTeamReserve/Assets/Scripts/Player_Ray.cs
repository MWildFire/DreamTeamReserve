using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lol
{
    public class Player_Ray : MonoBehaviour
    {
        public PauseInGame GeneralPauseScript;

        public bool in_Object = false;
        public bool Hint_E = false;
        private bool inventory = false;

        public int CollectedPictures = 0;
        public Text CollectedText;
        public GameObject note;
        public GameObject note_image;
        private bool isOpen;

        public Texture2D E_Hand_Image;

        List<Player_Item> list = new List<Player_Item>();
        public GameObject inventory_panel;
        public GameObject image_on_Slot;
        public GameObject inventory_layout;

        void Start()
        {
            inventory_panel.SetActive(false);
            note.SetActive(false);
        }

        void Update()
        {
            Debug.DrawRay(transform.position, transform.forward * 2.5f, Color.black);

            int Mask_Items = 1 << 10;
            int Mask_Pictures = 1 << 11;


            RaycastHit info;
            Ray _ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(_ray, out info, 2.5f, Mask_Items))
            {
                in_Object = true;
                Player_Item item = info.collider.GetComponent<Player_Item>();
                if (Input.GetKeyDown(KeyCode.E) && item != null)
                {
                    list.Add(item);
                    Destroy(info.collider.gameObject);
                }
            }
            else
            {
                in_Object = false;
            }

            if (in_Object)
            {
                Hint_E = true;
            }
            else if(in_Object == false && !Physics.Raycast(_ray, out info, 2.5f, Mask_Pictures))
            {
                Hint_E = false;
            }

            // ------------------------ Собирание листочков ------------------------

            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if(GeneralPauseScript.isPaused == false)
            {
                if (Physics.Raycast(ray, out hit, 2.5f))
                {
                    
                    if (hit.collider.GetComponent<Note>())
                    {
                        Hint_E = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            note.SetActive(true);
                            note_image.GetComponent<Image>().sprite = hit.collider.GetComponent<Note>().note_image;
                            isOpen = true;
                            Destroy(hit.collider.gameObject);
                            CollectedPictures += 1;
                            Hint_E = false;
                            GeneralPauseScript.isPaused = true;
                        }
                    }
                }
            }


            if (Input.GetKeyDown(KeyCode.Escape) && isOpen && GeneralPauseScript.isPaused == true)
            {
                note.SetActive(false);
                note_image.GetComponent<Image>().sprite = null;
                isOpen = false;
                GeneralPauseScript.isPaused = false;
            }

            CollectedText.text = "Собрано: " + CollectedPictures.ToString();

            // ----------------------------------------------------------------------

            Ray kp = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit find_kp;

            Debug.DrawRay(transform.position, transform.up, Color.cyan, 2.5f);
            if (GeneralPauseScript.isPaused == false)
            {
                if (Physics.Raycast(kp, out find_kp, 2.5f))
                {
                    if (find_kp.collider.GetComponent<Keypad>())
                    {
                        Hint_E = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            GeneralPauseScript.isPaused = true;
                            find_kp.collider.GetComponent<Keypad>().OpenPanel();
                        }
                        
                    }
                }
            }

            // ----------------------------------------------------------------------

            if (Input.GetKeyDown(KeyCode.I) && inventory == false && GeneralPauseScript.isPaused == false)
            {
                inventory_panel.SetActive(true);
                inventory = true;
                GeneralPauseScript.isPaused = true;

                int count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    Player_Item it = list[i];
                    if (inventory_layout.transform.childCount >= i)
                    {
                        GameObject img = Instantiate(image_on_Slot);
                        img.transform.SetParent(inventory_layout.transform.GetChild(i).transform);
                        img.GetComponent<Image>().sprite = Resources.Load<Sprite>(it.image_object);
                        img.AddComponent<Button>().onClick.AddListener(() => Remove(it, img));
                    }
                    else
                    {
                        break;
                    }
                }

            }
            else if (Input.GetKeyDown(KeyCode.I) && inventory && GeneralPauseScript.isPaused == true)
            {
                inventory_panel.SetActive(false);
                inventory = false;
                GeneralPauseScript.isPaused = false;

                for (int i = 0; i < inventory_layout.transform.childCount; i++)
                {
                    if (inventory_layout.transform.GetChild(i).transform.childCount > 0)
                    {
                        Destroy(inventory_layout.transform.GetChild(i).transform.GetChild(0).gameObject);
                    }
                }
            }


        }
        void Remove(Player_Item it, GameObject obj)
        {
            GameObject newo = Instantiate<GameObject>(Resources.Load<GameObject>(it.prefab_object));
            newo.transform.position = transform.position + transform.forward * 2.5f;
            Destroy(obj);
            list.Remove(it);
        }



        private void OnGUI()
        {
            if (Hint_E)
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 35, 100, 100), E_Hand_Image);
            }
        }
            
    }
}