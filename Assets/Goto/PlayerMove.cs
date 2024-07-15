using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float trpy = 2f;
    Rigidbody rb;
    Vector3 _move;
    float _horizontal;
    float _vertical;

    float _movespead = 5f;

    GameObject kome;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trp = transform.position;
        trp.y = trpy;
        transform.position = trp;

        Vector3 cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1).normalized);
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1).normalized);

        rb.velocity = Vector3.zero;
        _move = Vector3.zero;

        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _move += new Vector3(_horizontal * cameraRight.x, 0, _horizontal * cameraRight.z);
        _move += new Vector3(_vertical * cameraForward.x, 0, _vertical * cameraForward.z);
        _move = _move.normalized * _movespead;

        //_move = new Vector3(_horizontal, 0, _vertical).normalized * _movespead;

        rb.velocity = _move;

    }
}
