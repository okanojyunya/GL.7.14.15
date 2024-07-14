using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneM : MonoBehaviour
{
    //�V�ѕ��̃p�l��
    public GameObject _howtoPanel;
    //�N���W�b�g�̃p�l��
    public GameObject _creditPanel;
    //�t�F�[�h�p�摜
    public Image _fadeImage;
    //�t�F�[�h�X�s�[�h
    [SerializeField] private float _fadeTime;

    //�X�^�[�g�{�^��
    public void StartAction()
    {
        StartCoroutine(Fade(_fadeTime, "GameScene"));
    }

    //�V�ѕ��{�^��
    public void HowtoActive()
    {
        _howtoPanel.SetActive(true);
    }

    //�V�ѕ�����߂�{�^��
    public void HowtoAnactive()
    {
        _howtoPanel.SetActive(false);
    }

    //�V�ѕ��{�^��
    public void CreditActive()
    {
        _creditPanel.SetActive(true);
    }

    //�V�ѕ�����߂�{�^��
    public void CreditAnactive()
    {
        _creditPanel.SetActive(false);
    }

    //���X�^�[�g�{�^��
    public void ResetAction()
    {
        StartCoroutine(Fade(_fadeTime, "StartScene"));
    }

    //�R���[�`��
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
