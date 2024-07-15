using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    //何盛りか
    [SerializeField] private Text _resultText;
    //何粒集めたか
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
            _resultText.text = "ざんねん";
        }
        else if (ScoreManager.score > 0 && ScoreManager.score <= 149)
        {
            _resultText.text = "小盛";
            _douburi[0].SetActive(true);
        }
        else if (ScoreManager.score > 149 && ScoreManager.score <= 199)
        {
            _resultText.text = "中盛";
            _douburi[1].SetActive(true);
        }
        else if (ScoreManager.score > 199 && ScoreManager.score <= 299)
        {
            _resultText.text = "大盛";
            _douburi[2].SetActive(true);
        }
        else if (ScoreManager.score > 299)
        {
            _resultText.text = "熱盛";
            _douburi[3].SetActive(true);
        }
    }
}
