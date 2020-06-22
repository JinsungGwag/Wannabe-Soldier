using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public Text title;
    public Text content;

    public delegate void Callback();
    private Callback callback = null;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OK()
    {
        callback();
        gameObject.SetActive(false);
    }

    public void SetCallback(Callback cal)
    {
        callback = cal;
    }
}