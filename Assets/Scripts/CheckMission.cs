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
    
    private MissionComponent msComponent;

    public void Start()
    {
        msComponent = transform.parent.gameObject.GetComponent<MissionComponent>();
    }

    public void Check()
    {
        // 이미 성공한 업적이면 패쓰
        if (mission.success) return;

        checkPanel.Open();
        checkPanel.SetCallback(Success);
    }

    // 업적 성공 반영
    public void Success()
    {
        mission.success = !mission.success;
        dataManager.SaveMission();
    }
}
