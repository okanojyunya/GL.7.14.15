using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransSceneTimer : MonoBehaviour
{
    /// <summary>���Ԃ��͂���p</summary>
    private float _timer = 0.0f;
    /// <summary>�^�C�����~�b�g</summary>
    [SerializeField] private float _timeLimit = 60.0f;
    /// <summary>�^�C�}�[�̃e�L�X�g</summary>
    private Text _timerText;
    /// <summary>�t�F�[�h�p�摜</summary>
    public Image _fadeImage;
    [SerializeField] private float _fadeTime;

    private void Start()
    {
        _timerText = GetComponent<Text>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _timeLimit)
        {
            _timerText.text = ((int)_timeLimit - _timer).ToString("00");
        }
        GoResult();
    }
    void GoResult()
    {
        if (_timer >= _timeLimit)
        {
            StartCoroutine(Fade(_fadeTime, "ResultScene"));
        }
    }

    /// <summary>
    /// �R���[�`��
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator Fade(float interval, string sceneName)
    {
        float time = 0f;

        //�t�F�[�h�C��
        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            _fadeImage.color = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        // �V�[���񓯊����[�h
        yield return SceneManager.LoadSceneAsync(sceneName);

        // �t�F�[�h�A�E�g
        time = 0f;
        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            _fadeImage.color = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
