using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{
    public float time = 1;
    public new GameObject gameObject;

    void Start()
    {
        //��b��������J�n�̕����������B
        Destroy(base.gameObject, time);
    }
}
