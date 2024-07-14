using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    //���Ԃ��͂���p
    private float _timer = 0.0f;
    //�^�C�����~�b�g
    [SerializeField] private float _timeLimit = 60.0f;
    //�^�C�}�[�̃e�L�X�g
    private Text _timerText;

    private void Start()
    {
        _timerText = GetComponent<Text>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _timerText.text = ((int)_timeLimit - _timer).ToString("00");
        Debug.Log($"{_timer}");
        GoResult();
    }
    void GoResult()
    {
        if (_timer >= _timeLimit)
        {
            SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
        }
    }
}
