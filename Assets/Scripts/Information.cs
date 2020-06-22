using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information
{
    public Information(int level, string name, string rank, float value)
    {
        this.level = level;
        this.name = name;
        this.rank = rank;
        this.value = value;
    }

    public int level;
    public string name;
    public string rank;
    public float value;
}
