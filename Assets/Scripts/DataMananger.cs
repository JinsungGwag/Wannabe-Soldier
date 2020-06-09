using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataMananger : MonoBehaviour
{
    public Text category;
    public Text content;
    public Text price;

    public List<Mission> missionList = new List<Mission>();

    void Start()
    {
        LoadMission();
    }

    public void LoadMission()
    {

    }

    // 추가한 업적을 저장
    public void AddMission()
    {
        if (content.text == "" || price.text == "") return;
        Mission mission = new Mission(category.text, content.text, int.Parse(price.text));
        missionList.Add(mission);

        string dataJson = JsonConvert.SerializeObject(missionList);
        string filePath = Application.platform == RuntimePlatform.Android ? Application.persistentDataPath + "/Mission" : Application.streamingAssetsPath + "/Mission";
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);
        File.WriteAllText(filePath + "/UserMission.json", dataJson);
    }
}
