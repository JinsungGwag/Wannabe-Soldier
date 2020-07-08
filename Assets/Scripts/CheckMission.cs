using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMission : MonoBehaviour
{
    public Image success;
    public DataMananger dataManager;
    public UIManager uiManager;
    public Mission mission;
    public Panel checkPanel;
    public Animator clear;
    
    private MissionComponent msComponent;

    public void Start()
    {
        msComponent = transform.parent.gameObject.GetComponent<MissionComponent>();
    }

    public void Check()
    {
        // 이미 성공한 업적이면 패쓰
        if (mission.success) return;

        // 달성 확인창 생성
        checkPanel.title.text = "업적달성";
        checkPanel.content.text = "업적 달성을 완료하시겠습니까?";
        checkPanel.Open();
        checkPanel.SetCallback(Success);
    }

    // 업적 성공 반영
    public void Success()
    {
        mission.success = !mission.success;
        clear.SetTrigger("Clear");

        // 유저 경험치 상승
        float full = dataManager.userInfo.level * 20 + 100;
        float current = dataManager.userInfo.value;
        dataManager.userInfo.value = (current * full + mission.price) / full;
        
        // 레벨업을 했을 경우
        if(dataManager.userInfo.value >= 1)
        {
            dataManager.userInfo.level++;
            dataManager.userInfo.value -= 1;
        }

        // UI 스텟에 반영
        uiManager.levelTxt.text = "LV " + dataManager.userInfo.level;
        uiManager.valueImg.fillAmount = dataManager.userInfo.value;
        uiManager.valueTxt.text = (int)(dataManager.userInfo.value * 100) + "%";

        dataManager.SaveInformation();
        dataManager.SaveMission();
    }
}