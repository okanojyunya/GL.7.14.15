using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima1 : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            ani.SetBool("bl1", false);
            
        }
    }
}
