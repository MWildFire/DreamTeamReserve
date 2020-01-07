using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public string nameItem;
    public int id;
    public int countItem;
    public bool isStackable;
    [Multiline(5)]
    public string descriptionItem;
    public string pathIcon;
    public string pathPrefab;
    public bool isRemovable;
    public UnityEvent customEvent;
}
