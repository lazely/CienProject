using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public const int StageNum = 8;
    public StageInfo[] Stage = new StageInfo[StageNum];
    private GameObject CurrentStageObject = null;

    public GameObject timer;
    TextMeshPro timeText;
    private float time;
    private float TimeLimit = 300f; //second
    private int CurrentStage = -1;
    public Camera MainCamera;
    public GameObject Player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeText = timer.GetComponent<TextMeshPro>();
        time = TimeLimit;
        NextStage();
    }
    private void Update()
    {
        if (time <= 0)
        {
            timeText.text = "시간초과";
            Debug.Log("게임오버 - 타임아웃");
        }
        else
        {
            time -= Time.deltaTime; // 1/현재 프레임 (화면/s)
            if (time < 10)
            {
                timeText.text = "타이머 : " + $"{time:N2}";
            }
            else
            {
                timeText.text = "타이머 : " + Mathf.Floor(time).ToString();
            }

        }
    }

    public void NextStage()
    {
        CurrentStage++;
        if (CurrentStage >= 8)
        {
            CurrentStage = 0;
        }
        Destroy(CurrentStageObject);
        CurrentStageObject = Instantiate(Stage[CurrentStage].Stage_Prefab, new Vector3(0, 0, 0), Quaternion.identity);
        MainCamera.orthographicSize = Stage[CurrentStage].Camera_Size;
    }
}
