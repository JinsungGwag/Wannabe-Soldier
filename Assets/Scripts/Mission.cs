using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    public Mission(string category, string name, int price)
    {
        this.category = category;
        this.name = name;
        this.price = price;
    }

    public string category;
    public string name;
    public int price;
}
