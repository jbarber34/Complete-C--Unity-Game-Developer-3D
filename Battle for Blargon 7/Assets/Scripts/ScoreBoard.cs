using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;

    public void UpdateScore(int scoreIncrease)
    {
        score += scoreIncrease;
        Debug.Log("Score: " + score);
    }
}
