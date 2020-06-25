using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetProfile : MonoBehaviour
{
    public Text nameTxt;
    public Text rankTxt;
    public Text inYearTxt;
    public Text inMonthTxt;
    public Text inDayTxt;
    public Text outYearTxt;
    public Text outMonthTxt;
    public Text outDayTxt;
    public DataMananger dataManager;

    public void InitProfile()
    {
        if (nameTxt.text == "") return;

        dataManager.SetInformation(nameTxt.text, rankTxt.text, int.Parse(inYearTxt.text), int.Parse(inMonthTxt.text),
            int.Parse(inDayTxt.text), int.Parse(outYearTxt.text), int.Parse(outMonthTxt.text), int.Parse(outDayTxt.text));
        SceneManager.LoadScene("Main");
    }
}
