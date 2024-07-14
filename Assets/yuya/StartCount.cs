using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{
    public float time = 1;
    public new GameObject gameObject;

    void Start()
    {
        //ˆê•b‚½‚Á‚½‚çŠJn‚Ì•¶š‚ğÁ‚·B
        Destroy(base.gameObject, time);
    }
}
