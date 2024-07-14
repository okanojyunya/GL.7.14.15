using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public float bgmcount = 1;

    private AudioSource audioSource;

    public AudioClip bgmSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bgmcount -= Time.deltaTime;
        if (bgmcount <= 0)
        {
            audioSource.PlayOneShot(bgmSound);
            Debug.Log("bgm");
        }
    }
}
