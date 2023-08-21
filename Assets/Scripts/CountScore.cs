using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCounter;

    public float score = 0f;

    private string startingScoreText;

    private void Start()
    {
        startingScoreText = scoreCounter.text;
    }

    public void AddPoints()
    {
        score++;
        scoreCounter.text = startingScoreText + score;

    }

/*    public float GetScore()
    {
        return score;
    }*/

}

