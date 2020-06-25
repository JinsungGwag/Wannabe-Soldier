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
    public Image valueTxt;

    // Start is called before the first frame update
    void Start()
    {
        levelTxt.text = "LV " + dataManager.userInfo.level;
        nameTxt.text = "이름 " + dataManager.userInfo.name;
        rankTxt.text = "계급 " + dataManager.userInfo.rank;
        valueTxt.fillAmount = dataManager.userInfo.value;
    }
}
