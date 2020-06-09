using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public GameObject content;
    public GameObject missionContent;
    public Text categoryLabel;

    public void Start()
    {
        ChangeList();
    }

    public void ChangeList()
    {
        // 미션 리스트 초기화
        Transform[] childList = content.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

        string category = categoryLabel.text;

        foreach(Mission mission in MissionList.missions)
        {
            if(mission.category == category)
            {
                GameObject rightMission = Instantiate(missionContent);
                rightMission.GetComponent<MissionComponent>().msName.text = mission.name;
                rightMission.GetComponent<MissionComponent>().msPrice.text = mission.price + "";
                rightMission.transform.parent = content.transform;
                rightMission.transform.localScale = missionContent.transform.localScale;
            }
        }
    }

    // 업적 추가 및 데이터 저장
    public void AddMission()
    {
    }
}
