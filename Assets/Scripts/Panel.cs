using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
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
