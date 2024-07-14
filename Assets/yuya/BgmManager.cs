using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    //�J�E���g�_�E���J�n
    public float bgmcount = 1;

    private AudioSource audioSource;

    public AudioClip bgmSound;

    void Start()
    {
        //�I�[�f�B�I�\�[�X���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bgmcount -= Time.deltaTime;

        //bgmcount��0�ȉ��ɂȂ����Ƃ�
        if (bgmcount <= 0)
        {
            //bgm��炷�B
            audioSource.PlayOneShot(bgmSound);
        }
    }
}
