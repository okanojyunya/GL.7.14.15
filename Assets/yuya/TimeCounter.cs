using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //�J�E���g�_�E��
    private float startcount = 1f;

    public float countdown = 5f;
    //���Ԃ�\������Text�^�̕ϐ�

    public Text timeText;

    //�I�[�f�B�I�\�[�X
    private AudioSource audioSource;

    //�X�^�[�g�̉�
    public AudioClip startSound;

    //�^�C���A�b�v�̉�
    public AudioClip timeUpSound;

    private void Start()
    {
        //�I�[�f�B�I�\�[�X�擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //�Q�[���J�n�܂ł��J�E���g�_�E������B
        startcount -= Time.deltaTime;

        //startcount��0�ȉ��ɂȂ����Ƃ�
        if (startcount <= 0)
        {
            //�X�^�[�g�̉���炷�B
            audioSource.PlayOneShot(startSound);

            if (startcount +1 <= 0)
            {
                countdown -= Time.deltaTime;
                //�J�E���g�_�E���J�n�I
                timeText.text = countdown.ToString("f1") + "�b";
            }
        }

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (countdown <= 0)
        {
            //�Q�[���I���I
            timeText.text = "�I���I";
            //�^�C���A�b�v�̉���炷�B
            audioSource.PlayOneShot(timeUpSound);

            //�I������0.5�b�o�߂�����
            if (countdown +1.5 <= 0)
            {
                //Csene��ς���
                SceneManager.LoadScene("Scene Name");
                //Scene Name�����U���g�̃V�[���ɏ���������B
            }
        }
    }
}