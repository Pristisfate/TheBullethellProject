using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Enemy _enemy;

    public int Score = 0;

    private void Update()
    {
        OnScoreChanged(Score);
    }
    public void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}
