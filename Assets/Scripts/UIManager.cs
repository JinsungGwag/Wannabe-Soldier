using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public DataMananger dataManager;
    
    public Text levelTxt;
    public Text nameTxt;
    public Text rankTxt;
    public Text valueTxt;
    public Image valueImg;

    // Start is called before the first frame update
    void Start()
    {
        levelTxt.text = "LV " + dataManager.userInfo.level;
        nameTxt.text = "이름 " + dataManager.userInfo.name;
        rankTxt.text = "계급 " + dataManager.userInfo.rank;
        valueTxt.text = (int)(dataManager.userInfo.value * 100) + "%";
        valueImg.fillAmount = dataManager.userInfo.value;
    }
}
