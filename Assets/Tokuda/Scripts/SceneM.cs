using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneM : MonoBehaviour
{
    /// <summary>�V�ѕ��̃p�l��</summary>
    public GameObject _howtoPanel;
    /// <summary>�N���W�b�g�̃p�l��</summary>
    public GameObject _creditPanel;
    /// <summary>�t�F�[�h�p�摜</summary>
    public Image _fadeImage;
    /// <summary>�t�F�[�h�X�s�[�h</summary>
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

    //�N���W�b�g�{�^��
    public void CreditActive()
    {
        _creditPanel.SetActive(true);
    }

    //�N���W�b�g����߂�{�^��
    public void CreditAnactive()
    {
        _creditPanel.SetActive(false);
    }

    //���X�^�[�g�{�^��
    public void ResetAction()
    {
        StartCoroutine(Fade(_fadeTime, "StartScene"));
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
