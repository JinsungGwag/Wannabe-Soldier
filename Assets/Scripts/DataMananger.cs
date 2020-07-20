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
    public Information userInfo;
    
    public Text category;
    public Text content;
    public Text price;

    public Panel removePanel;
    public GameObject addPanel;
    public MissionManager missionManager;

    public List<Mission> missionList = new List<Mission>();
    public List<SaleEvent> saleList = new List<SaleEvent>();
    public List<Welfare> welfareList = new List<Welfare>();
    public List<Supply> supplyList = new List<Supply>();
    public List<PX> pxList = new List<PX>();
    public List<TMO> tmoList = new List<TMO>();

    void Start()
    {
        informationPath = Path.Combine(Application.persistentDataPath, "Information");
        missionPath = Path.Combine(Application.persistentDataPath, "Mission");
        LoadMission();
        LoadInformation();
        LoadSale();
        LoadWelfare();
        LoadSupply();
        LoadPX();
        LoadTMO();
    }

    // 사용자 정보 불러오기
    public bool LoadInformation()
    {
        if (!Directory.Exists(informationPath)) return false;
        if (!File.Exists(Path.Combine(informationPath, "UserInformation.json"))) return false;

        // 저장된 정보가 있을 경우 불러옴
        string dataJson = File.ReadAllText(Path.Combine(informationPath, "UserInformation.json"), Encoding.UTF8);
        userInfo = JsonConvert.DeserializeObject<Information>(dataJson);
        
        return true;
    }

    // 할인 정보 불러오기
    public void LoadSale()
    {
        TextAsset textAsset = Resources.Load("sale") as TextAsset;
        string dataJson = Encoding.UTF8.GetString(textAsset.bytes);
        saleList = JsonConvert.DeserializeObject<List<SaleEvent>>(dataJson);
    }

    // 복지 정보 불러오기
    public void LoadWelfare()
    {
        TextAsset textAsset = Resources.Load("welfare") as TextAsset;
        string dataJson = Encoding.UTF8.GetString(textAsset.bytes);
        welfareList = JsonConvert.DeserializeObject<List<Welfare>>(dataJson);
    }

    // 보급 정보 불러오기
    public void LoadSupply()
    {
        TextAsset textAsset = Resources.Load("supply") as TextAsset;
        string dataJson = Encoding.UTF8.GetString(textAsset.bytes);
        supplyList = JsonConvert.DeserializeObject<List<Supply>>(dataJson);
    }

    // PX 정보 불러오기
    public void LoadPX()
    {
        TextAsset textAsset = Resources.Load("PX") as TextAsset;
        string dataJson = Encoding.UTF8.GetString(textAsset.bytes);
        pxList = JsonConvert.DeserializeObject<List<PX>>(dataJson);
    }

    // TMO 정보 불러오기
    public void LoadTMO()
    {
        TextAsset textAsset = Resources.Load("TMO") as TextAsset;
        string dataJson = Encoding.UTF8.GetString(textAsset.bytes);
        tmoList = JsonConvert.DeserializeObject<List<TMO>>(dataJson);
    }

    public void SetInformation(string name, string rank, int inYear, int inMonth, int inDay, int outYear, int outMonth, int outDay)
    {
        userInfo = new Information(name, rank, inYear, inMonth, inDay, outYear, outMonth, outDay);
        SaveInformation();
    }

    // 사용자 정보 저장하기
    public void SaveInformation()
    {
        string dataJson = JsonConvert.SerializeObject(userInfo);
        if (!Directory.Exists(informationPath))
            Directory.CreateDirectory(informationPath);
        File.WriteAllText(Path.Combine(informationPath, "UserInformation.json"), dataJson, Encoding.UTF8);
    }

    // 삭제할 업적 이름 기억
    public void ChangeName()
    {
        removeName = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<MissionComponent>().msName.text;
    }

    public void LoadMission()
    {
        if (!Directory.Exists(missionPath))
        {
            Directory.CreateDirectory(missionPath);
            missionList.Add(new Mission("운동", "3KM 12분 30초(특)", 60, false));
            missionList.Add(new Mission("운동", "팔굽혀펴기 72개(특)", 60, false));
            missionList.Add(new Mission("운동", "윗몸일으키기 86개(특)", 60, false));
            missionList.Add(new Mission("휴가", "국가공인 자격증 따기", 50, false));
            missionList.Add(new Mission("휴가", "특급전사 달성하기", 70, false));
            missionList.Add(new Mission("휴가", "독립기념관 다녀오기", 40, false));
            missionList.Add(new Mission("공부", "토익 700점 이상 달성", 50, false));
            SaveMission();
        }
        
        // 저장된 업적이 있을 경우 불러옴
        string dataJson = File.ReadAllText(Path.Combine(missionPath, "UserMission.json"), Encoding.UTF8);
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
        File.WriteAllText(Path.Combine(missionPath, "UserMission.json"), dataJson, Encoding.UTF8);
        missionManager.ChangeList();
    }
}