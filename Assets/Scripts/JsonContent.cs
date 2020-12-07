using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JsonContent
{
    public int NumberStock;
    public List<ItemContent> listItems;

}
[Serializable]
public class ItemContent
{
    public string Name;
    public string NameOwner;
    public int Count;
    public int Price;
    public int CountStarOwner;
    public string NameIcon;
    public string IconOwnerDataBase64String;
    public int width;
    public int height;
}
