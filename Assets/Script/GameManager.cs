using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool isGameCleared;
    public const int StageNum = 8;
    public StageInfo[] Stage = new StageInfo[StageNum];
    public int CurrentStage;
    private GameObject CurrentStageObject = null;
    private Camera MainCamera;

    public int Score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Cien Project")
        {
            if (isGameCleared)
            {
                isGameCleared = false;
                MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                NextStage();
            }
        }
    }

    public void NextStage()
    {
        Score++;
        CurrentStage++;
        if (CurrentStage >= StageNum)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        Destroy(CurrentStageObject);
        CurrentStageObject = Instantiate(Stage[CurrentStage].Stage_Prefab, new Vector3(0, 0, 0), Quaternion.identity);
        MainCamera.orthographicSize = Stage[CurrentStage].Camera_Size;
    }
}
