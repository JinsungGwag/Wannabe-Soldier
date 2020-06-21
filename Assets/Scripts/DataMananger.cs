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
    private string filePath;
    private string removeName = null;

    public Text category;
    public Text content;
    public Text price;

    public GameObject addPanel;
    public MissionManager missionManager;

    public List<Mission> missionList = new List<Mission>();

    void Start()
    {
        filePath = Application.platform == RuntimePlatform.Android ? Application.persistentDataPath + "/Mission" : Application.streamingAssetsPath + "/Mission";
        LoadMission();
    }

    public void ChangeName()
    {
        removeName = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<MissionComponent>().msName.text;
    }

    public void LoadMission()
    {
        if (!Directory.Exists(filePath)) return;
        if (!File.Exists(filePath + "/UserMission.json")) return;

        // 저장된 업적이 있을 경우 불러옴
        string dataJson = File.ReadAllText(filePath + "/UserMission.json", Encoding.Unicode);
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

    // 지정한 업적 삭제
    public void RemoveMission()
    {
        if (removeName == null) return;

        foreach(Mission mission in missionList)
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
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);
        File.WriteAllText(filePath + "/UserMission.json", dataJson, Encoding.Unicode);
        missionManager.ChangeList();
    }
}