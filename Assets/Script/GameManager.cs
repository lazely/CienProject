using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    struct Info
    {
        public Vector3 Camera_pos;
        public int Camera_size;
        public Vector3 Player_pos;
        public Quaternion Player_rot;
    }
    public GameObject timer;
    TextMeshPro timeText;
    private float time;
    private float TimeLimit = 300f; //second
    const int StageNum = 8;
    public int CurrentStage = 0;
    Info[] Level_Info = new Info[StageNum+1];
    public Camera MainCamera;
    public GameObject Player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Level_Info[0].Camera_pos = new Vector3(0, 0, -10);
        Level_Info[0].Camera_size = 25;
        Level_Info[0].Player_pos = new Vector3(-17.5f, -2.5f, 0);
        Level_Info[0].Player_rot = Quaternion.Euler(0, 0, 90);

        Level_Info[1].Camera_pos = new Vector3(0, 0, -10);
        Level_Info[1].Camera_size = 25;
        Level_Info[1].Player_pos = new Vector3(-17.5f, -2.5f, 0);
        Level_Info[1].Player_rot = Quaternion.Euler(0, 0, 90);

        Level_Info[2].Camera_pos = new Vector3(80, -5, -10);
        Level_Info[2].Camera_size = 30;
        Level_Info[2].Player_pos = new Vector3(57.5f, -7.5f, 0);
        Level_Info[2].Player_rot = Quaternion.Euler(0, 0, 90);

        Level_Info[3].Camera_pos = new Vector3(150, 0, -10);
        Level_Info[3].Camera_size = 25;
        Level_Info[3].Player_pos = new Vector3(167.5f, -7.5f, 0);
        Level_Info[3].Player_rot = Quaternion.Euler(0, 0, 90);

        Level_Info[4].Camera_pos = new Vector3(5, -80, -10);
        Level_Info[4].Camera_size = 30;
        Level_Info[4].Player_pos = new Vector3(22.5f, -97.5f, 0);
        Level_Info[4].Player_rot = Quaternion.Euler(0, 0, 90);

        Level_Info[5].Camera_pos = new Vector3(80, -80, -10);
        Level_Info[5].Camera_size = 30;
        Level_Info[5].Player_pos = new Vector3(97.5f, -102.5f, 0);
        Level_Info[5].Player_rot = Quaternion.Euler(0, 0, 90);

        Level_Info[6].Camera_pos = new Vector3(155, -80, -10);
        Level_Info[6].Camera_size = 30;
        Level_Info[6].Player_pos = new Vector3(172.5f, -102.5f, 0);
        Level_Info[6].Player_rot = Quaternion.Euler(0, 0, 90);

        Level_Info[7].Camera_pos = new Vector3(0, -150, -10);
        Level_Info[7].Camera_size = 25;
        Level_Info[7].Player_pos = new Vector3(-17.5f, -162.5f, 0);
        Level_Info[7].Player_rot = Quaternion.Euler(0, 0, 90);

        Level_Info[8].Camera_pos = new Vector3(85, -160, -10);
        Level_Info[8].Camera_size = 35;
        Level_Info[8].Player_pos = new Vector3(85f, -160f, 0);
        Level_Info[8].Player_rot = Quaternion.Euler(0, 0, 90);

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
        if(CurrentStage != 0)
        {
            GameObject.Find("Stage").transform.Find("Stage " + CurrentStage.ToString()).gameObject.SetActive(false);
        }
        CurrentStage++;
        if(CurrentStage >= 9)
        {
            CurrentStage = 1;
        }
        GameObject.Find("Stage").transform.Find("Stage " + CurrentStage.ToString()).gameObject.SetActive(true);
        MainCamera.transform.position = Level_Info[CurrentStage].Camera_pos;
        MainCamera.orthographicSize = Level_Info[CurrentStage].Camera_size;
        Player.transform.position = Level_Info[CurrentStage].Player_pos;
        Player.transform.rotation = Level_Info[CurrentStage].Player_rot;
    }
}
