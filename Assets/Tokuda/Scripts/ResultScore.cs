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
    [SerializeField] private GameObject[] _douburi;
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
            _douburi[0].SetActive(true);
        }
        else if (ScoreManager.score > 149 && ScoreManager.score <= 199)
        {
            _resultText.text = "íÜê∑";
            _douburi[1].SetActive(true);
        }
        else if (ScoreManager.score > 199 && ScoreManager.score <= 299)
        {
            _resultText.text = "ëÂê∑";
            _douburi[2].SetActive(true);
        }
        else if (ScoreManager.score > 299)
        {
            _resultText.text = "îMê∑";
            _douburi[3].SetActive(true);
        }
    }
}
