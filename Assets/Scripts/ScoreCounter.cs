using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _score = 0;

    private void Start()
    {
        _text.text = 0.ToString();
    }

    public void OnScoreChanged()
    {
        _score++;
        _text.text = _score.ToString();
    }
}
