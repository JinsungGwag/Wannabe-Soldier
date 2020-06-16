using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMission : MonoBehaviour
{
    public Image success;
    public DataMananger dataManager;
    public Mission mission;

    private MissionComponent msComponent;

    public void Start()
    {
        msComponent = transform.parent.gameObject.GetComponent<MissionComponent>();
    }

    public void Check()
    {
        mission.success = !mission.success;
        dataManager.SaveMission();
    }
}
