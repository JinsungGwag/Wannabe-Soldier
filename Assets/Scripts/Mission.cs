using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    public Mission(string category, string name, int price, bool success)
    {
        this.category = category;
        this.name = name;
        this.price = price;
        this.success = success;
    }

    public string category;
    public string name;
    public int price;
    public bool success;
}
