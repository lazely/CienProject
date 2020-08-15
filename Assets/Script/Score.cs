using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI ScoreText;
    //TextMeshPro ScoreText;
    private int bestscore;
    private int currentscore;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = transform.GetComponent<TextMeshProUGUI>();
        bestscore = GameManager.instance.BestScore;
        currentscore = GameManager.instance.Score;

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Best Score : " + bestscore.ToString() + "\nCurrent Score : " + currentscore;
    }
}
