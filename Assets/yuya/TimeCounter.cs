using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //カウントダウン
    public float startcount = 1f;

    public float countdown = 5.0f;

    //時間を表示するText型の変数
    public Text startText;

    public Text timeText;

    //オーディオソース
    private AudioSource audioSource;

    //スタートの音
    public AudioClip startSound;

    //タイムアップの音
    public AudioClip timeUpSound;


    private void Start()
    {
        //オーディオソース取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //ゲーム開始までをカウントダウンする。
        startcount -= Time.deltaTime;

        //時間を表示する。
        startText.text = startcount.ToString("f1")+"秒" ;

        //startcountが0以下になったとき
        if (startcount <= 0)
        {
            startText.text = "開始";
            audioSource.PlayOneShot(startSound);

            //開始から1秒経過したら
            if (startcount +1 <= 0)
            {
                countdown -= Time.deltaTime;
                //カウントダウン開始！
                timeText.text = countdown.ToString("f1") + "秒";
            }
        }

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            //ゲーム終了！
            timeText.text = "終了！";
            //タイムアップの音を鳴らす。
            audioSource.PlayOneShot(timeUpSound);

            //終了から0.5秒経過したら
            if (countdown +1.5 <= 0)
            {
                //Cseneを変える
                SceneManager.LoadScene("Scene Name");
                //Scene Nameをリザルトのシーンに書き換える。
            }
        }
    }
}