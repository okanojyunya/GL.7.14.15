using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    Vector3 _move;
    float _horizontal;
    float _vertical;

    float _movespead = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;

        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _move = new Vector3(_horizontal, 0, _vertical).normalized * _movespead;
        

        rb.velocity = _move;

        Debug.Log(_horizontal);
    }
}
