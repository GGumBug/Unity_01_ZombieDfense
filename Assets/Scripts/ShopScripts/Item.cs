using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName;
    public int price;

    public Item(string name, int price)
    {
        itemName = name;
        this.price = price;
    }
}
