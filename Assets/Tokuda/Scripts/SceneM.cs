using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneM : MonoBehaviour
{
    /// <summary>遊び方のパネル</summary>
    public GameObject _howtoPanel;
    /// <summary>クレジットのパネル</summary>
    public GameObject _creditPanel;
    /// <summary>フェード用画像</summary>
    public Image _fadeImage;
    /// <summary>フェードスピード</summary>
    [SerializeField] private float _fadeTime;

    //スタートボタン
    public void StartAction()
    {
        StartCoroutine(Fade(_fadeTime, "GameScene"));
    }

    //遊び方ボタン
    public void HowtoActive()
    {
        _howtoPanel.SetActive(true);
    }

    //遊び方から戻るボタン
    public void HowtoAnactive()
    {
        _howtoPanel.SetActive(false);
    }

    //クレジットボタン
    public void CreditActive()
    {
        _creditPanel.SetActive(true);
    }

    //クレジットから戻るボタン
    public void CreditAnactive()
    {
        _creditPanel.SetActive(false);
    }

    //リスタートボタン
    public void ResetAction()
    {
        StartCoroutine(Fade(_fadeTime, "StartScene"));
    }

    /// <summary>
    /// コルーチン
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator Fade(float interval, string sceneName)
    {
        float time = 0f;

        //フェードイン
        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            _fadeImage.color = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        // シーン非同期ロード
        yield return SceneManager.LoadSceneAsync(sceneName);

        // フェードアウト
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
