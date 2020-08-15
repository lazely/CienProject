using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI ScoreText;
    //TextMeshPro ScoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = transform.GetComponent<TextMeshProUGUI>();
        score = GameManager.instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
