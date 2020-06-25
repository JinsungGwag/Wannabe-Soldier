using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information
{
    public Information(string name, string rank, int inYear, int inMonth, int inDay, int outYear, int outMonth, int outDay)
    {
        level = 0;
        value = 0;
        this.name = name;
        this.rank = rank;
        this.inYear = inYear;
        this.inMonth = inMonth;
        this.inDay = inDay;
        this.outYear = outYear;
        this.outMonth = outMonth;
        this.outDay = outDay;
    }

    public int level;
    public float value;
    public string name;
    public string rank;
    public int inYear;
    public int inMonth;
    public int inDay;
    public int outYear;
    public int outMonth;
    public int outDay;
}
