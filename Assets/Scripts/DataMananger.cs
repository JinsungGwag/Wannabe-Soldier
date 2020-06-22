using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataMananger : MonoBehaviour
{
    private string informationPath;
    private string missionPath;
    private string removeName = null;

    // 사용자 정보
    private int userLevel;
    private string userName;
    private string userRank;
    private float userValue; 

    public Text category;
    public Text content;
    public Text price;

    public Panel removePanel;
    public GameObject addPanel;
    public MissionManager missionManager;

    public List<Mission> missionList = new List<Mission>();

    void Start()
    {
        informationPath = Application.platform == RuntimePlatform.Android ? Application.persistentDataPath + "/Information" : Application.streamingAssetsPath + "/Information";
        missionPath = Application.platform == RuntimePlatform.Android ? Application.persistentDataPath + "/Mission" : Application.streamingAssetsPath + "/Mission";
        LoadMission();
    }

    // 사용자 정보 불러오기
    public bool LoadInformation()
    {
        if (!Directory.Exists(informationPath)) return false;
        if (!File.Exists(informationPath + "/UserInformation.json")) return false;

        // 저장된 정보가 있을 경우 불러옴
        string dataJson = File.ReadAllText(informationPath + "/UserInformation.json", Encoding.Unicode);
        Information userInfo = JsonConvert.DeserializeObject<Information>(dataJson);

        userLevel = userInfo.level;
        userName = userInfo.name;
        userRank = userInfo.rank;
        userValue = userInfo.value;

        return true;
    }

    // 삭제할 업적 이름 기억
    public void ChangeName()
    {
        removeName = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<MissionComponent>().msName.text;
    }

    public void LoadMission()
    {
        if (!Directory.Exists(missionPath)) return;
        if (!File.Exists(missionPath + "/UserMission.json")) return;

        // 저장된 업적이 있을 경우 불러옴
        string dataJson = File.ReadAllText(missionPath + "/UserMission.json", Encoding.Unicode);
        missionList = JsonConvert.DeserializeObject<List<Mission>>(dataJson);
    }

    // 추가한 업적을 저장
    public void AddMission()
    {
        if (content.text == "" || price.text == "") return;
        Mission mission = new Mission(category.text, content.text, int.Parse(price.text), false);
        missionList.Add(mission);

        SaveMission();
        addPanel.SetActive(false);
    }
    
    public void OpenRemovePanel()
    {
        if (removeName == null) return;

        // 해당 업적이 존재하는지 확인
        bool check = false;
        foreach (Mission mission in missionList)
        {
            if (mission.name == removeName)
            {
                check = true;
                break;
            }
        }
        if (!check) return;

        // 제거 확인창 생성
        removePanel.title.text = "업적제거";
        removePanel.content.text = "<" + removeName + ">\n업적을 제거하시겠습니까?";
        removePanel.Open();
        removePanel.SetCallback(RemoveMission);
    }
    
    // 업적 제거
    public void RemoveMission()
    {
        foreach (Mission mission in missionList)
        {
            if (mission.name == removeName)
            {
                missionList.Remove(mission);
                break;
            }
        }

        SaveMission();
    }

    // 변경사항을 저장
    public void SaveMission()
    {
        string dataJson = JsonConvert.SerializeObject(missionList);
        if (!Directory.Exists(missionPath))
            Directory.CreateDirectory(missionPath);
        File.WriteAllText(missionPath + "/UserMission.json", dataJson, Encoding.Unicode);
        missionManager.ChangeList();
    }
}