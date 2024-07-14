using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{
    public float time = 1;
    public new GameObject gameObject;

    void Start()
    {
        Destroy(base.gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
