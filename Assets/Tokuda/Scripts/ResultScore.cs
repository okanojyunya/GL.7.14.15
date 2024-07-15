using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    //�����肩
    [SerializeField] private Text _resultText;
    //�����W�߂���
    [SerializeField] private Text _scoreText;
    //�B���x���Ƃɕ\����ς���p
    [SerializeField] private GameObject[] _douburi;
    [SerializeField] private int[] _level;
    // Start is called before the first frame update
    void Start()
    {
        _resultText = GetComponentInChildren<Text>();
        Debug.Log(ScoreManager.score);
        _scoreText.text = ScoreManager.score.ToString();
        if (ScoreManager.score >= 0 && ScoreManager.score <= _level[0])
        {
            _resultText.text = "����";
            _douburi[0].SetActive(true);
        }
        else if (ScoreManager.score > _level[0] && ScoreManager.score <= _level[1])
        {
            _resultText.text = "����";
            _douburi[1].SetActive(true);
        }
        else if (ScoreManager.score > _level[1] && ScoreManager.score <= _level[2])
        {
            _resultText.text = "�吷";
            _douburi[2].SetActive(true);
        }
        else if (ScoreManager.score > _level[2])
        {
            _resultText.text = "�M��";
            _douburi[3].SetActive(true);
        }
    }
}
