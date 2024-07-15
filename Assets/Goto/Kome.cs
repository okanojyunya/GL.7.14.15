using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kome : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    AI _ai;
    bool _hitLaser = false;
    // Start is called before the first frame update
    void Start()
    {
        _ai = GetComponent<AI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitLaser)
        {

            Vector3 suikomi = Vector3.Lerp(transform.position, _gameObject.transform.position, Time.deltaTime * 3f);
            transform.position = suikomi;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _hitLaser = true;
            _ai.StoppedNavMeshAgent();
        }
    }
}
