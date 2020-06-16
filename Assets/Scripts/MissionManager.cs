using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public GameObject content;
    public GameObject missionContent;
    public Text categoryLabel;

    public DataMananger dataManager;

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

        dataManager.LoadMission();
        string category = categoryLabel.text;

        foreach(Mission mission in dataManager.missionList)
        {
            if(mission.category == category)
            {
                GameObject rightMission = Instantiate(missionContent);
                MissionComponent msComponent = rightMission.GetComponent<MissionComponent>();
                rightMission.GetComponentInChildren<CheckMission>().mission = mission;
                msComponent.msName.text = mission.name;
                msComponent.msPrice.text = mission.price + "";

                // 카테고리 이미지 설정
                switch(category)
                {
                    case "여행":
                        msComponent.msCategory.sprite = msComponent.travel;
                        break;

                    case "휴가":
                        msComponent.msCategory.sprite = msComponent.vacation;
                        break;

                    case "운동":
                        msComponent.msCategory.sprite = msComponent.sport;
                        break;

                    case "공부":
                        msComponent.msCategory.sprite = msComponent.study;
                        break;

                    case "기타":
                        msComponent.msCategory.sprite = msComponent.etc;
                        break;

                    default:
                        break;
                }

                // 업적 달성 여부 표시
                if (mission.success)
                    msComponent.msCheck.sprite = msComponent.success;
                else
                    msComponent.msCheck.sprite = msComponent.fail;

                rightMission.transform.parent = content.transform;
                rightMission.transform.localScale = missionContent.transform.localScale;
                rightMission.transform.localPosition = new Vector3(rightMission.transform.localPosition.x, rightMission.transform.localPosition.y, 0);
                rightMission.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
