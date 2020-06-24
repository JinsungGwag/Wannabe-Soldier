using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    public Dropdown year;
    public Dropdown month;
    public Dropdown day;

    public List<string> yearList;
    public List<string> monthList;

    void Start()
    {
        year.AddOptions(yearList);
        month.AddOptions(monthList);
        ChangeDay();
    }
    
    public void ChangeDay()
    {
        day.options.Clear();

        int numYear = int.Parse(year.captionText.text);
        int numMonth = int.Parse(month.captionText.text);

        if (numMonth == 2)
        {
            if (numYear % 4 == 0)
            {
                for (int i = 1; i <= 29; i++)
                    day.options.Add(new Dropdown.OptionData(i + ""));
            }
            else
            {
                for (int i = 1; i <= 28; i++)
                    day.options.Add(new Dropdown.OptionData(i + ""));
            }
        }
        else if (numMonth == 1 || numMonth == 3 || numMonth == 5 || numMonth == 7 || numMonth == 8 || numMonth == 10 || numMonth == 12)
        {
            for (int i = 1; i <= 31; i++)
                day.options.Add(new Dropdown.OptionData(i + ""));
        }
        else
        {
            for (int i = 1; i <= 30; i++)
                day.options.Add(new Dropdown.OptionData(i + ""));
        }
    }
}
