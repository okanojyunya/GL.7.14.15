using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{
    public float time = 1;
    public new GameObject gameObject;

    void Start()
    {
        //一秒たったら開始の文字を消す。
        Destroy(base.gameObject, time);
    }
}
