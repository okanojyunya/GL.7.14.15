using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    //âΩê∑ÇËÇ©
    [SerializeField] private Text _resultText;
    //âΩó±èWÇﬂÇΩÇ©
    [SerializeField] private Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _resultText = GetComponentInChildren<Text>();
        Debug.Log(ScoreManager.score);
        _scoreText.text = ScoreManager.score.ToString();
        if (ScoreManager.score == 0)
        {
            _resultText.text = "Ç¥ÇÒÇÀÇÒ";
        }
        else if (ScoreManager.score > 0 && ScoreManager.score <= 149)
        {
            _resultText.text = "è¨ê∑";
        }
        else if (ScoreManager.score > 149 && ScoreManager.score <= 199)
        {
            _resultText.text = "íÜê∑";
        }
        else if (ScoreManager.score > 199 && ScoreManager.score <= 299)
        {
            _resultText.text = "ëÂê∑";
        }
        else if (ScoreManager.score > 299)
        {
            _resultText.text = "îMê∑";
        }
    }
}
