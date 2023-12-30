using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }

    public void UpdateScore(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = score.ToString();

    }
}
