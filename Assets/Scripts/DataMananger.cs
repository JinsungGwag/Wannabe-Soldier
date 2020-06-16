using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DataMananger : MonoBehaviour
{
    private string filePath;

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
        
        string dataJson = JsonConvert.SerializeObject(missionList);
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);
        File.WriteAllText(filePath + "/UserMission.json", dataJson, Encoding.Unicode);
        addPanel.SetActive(false);
        missionManager.ChangeList();
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