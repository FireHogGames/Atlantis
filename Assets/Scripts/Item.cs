using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/New", order = 1)]
public class Item : ScriptableObject
{
    public string name;
    public string description;
}
