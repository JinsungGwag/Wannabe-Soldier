using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMission : MonoBehaviour
{
    public Image success;
    public DataMananger dataManager;
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
        dataManager.SaveMission();
    }
}