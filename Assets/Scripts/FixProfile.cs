using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixProfile : MonoBehaviour
{
    public UIManager uiManager;
    public DataMananger dataManager;

    public Dropdown rankDropdown;
    public InputField nameField;

    public void LoadCurrentInformation()
    {
        for(int i = 0; i < rankDropdown.options.Count; i++)
        {
            if(rankDropdown.options[i].text == dataManager.userInfo.rank)
            {
                rankDropdown.value = i;
                break;
            }
        }
        nameField.text = dataManager.userInfo.name;
    }

    public void UpdateInformation()
    {
        uiManager.rankTxt.text = "계급 " + rankDropdown.captionText.text;
        uiManager.nameTxt.text = "이름 " + nameField.text;
        dataManager.userInfo.rank = rankDropdown.captionText.text;
        dataManager.userInfo.name = nameField.text;
        dataManager.SaveInformation();
    }
}
