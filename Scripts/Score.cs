using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int PlayerScore;
    public static int EnemyScore;
    public Text ScoreText;

    void Start()
    {

    }

    void Update()
    {
        ScoreText.text = $"Kills: {PlayerScore} : {EnemyScore}";
    }
}
