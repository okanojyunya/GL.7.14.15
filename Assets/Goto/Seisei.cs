using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seisei : MonoBehaviour
{
    [SerializeField] GameObject kome;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(kome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
