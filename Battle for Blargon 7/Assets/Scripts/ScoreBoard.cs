using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    [SerializeField] private FloatSO scoreSO;


    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        // scoreText.text = "Start";
        scoreText.text = scoreSO.Value.ToString();
    }

    public void UpdateScore(int scoreIncrease)
    {
        scoreSO.Value += scoreIncrease;
        scoreText.text = scoreSO.Value.ToString();

    }
}
