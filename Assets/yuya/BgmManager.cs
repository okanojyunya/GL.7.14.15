using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    //カウントダウン開始
    public float bgmcount = 1;

    private AudioSource audioSource;

    public AudioClip bgmSound;

    void Start()
    {
        //オーディオソースを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bgmcount -= Time.deltaTime;

        //bgmcountが0以下になったとき
        if (bgmcount <= 0)
        {
            //bgmを鳴らす。
            audioSource.PlayOneShot(bgmSound);
        }
    }
}
