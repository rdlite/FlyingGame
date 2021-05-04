using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData")]
public class ScoreData : ScriptableObject
{
    public int CurrentScore;
    public int HighestScore;

    public void NulifyStartScore()
    {
        CurrentScore = 0;
    }
}