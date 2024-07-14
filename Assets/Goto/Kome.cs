using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kome : MonoBehaviour
{
    GameObject _player;
    GameObject _laser;
    AI _ai;
    bool _hitLaser = false;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Suikomiguti");
        _laser = GameObject.Find("Laser");
        _ai = GetComponent<AI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitLaser)
        {

            Vector3 suikomi = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime * 3f);
            transform.position = suikomi;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            _hitLaser = true;
            _ai.StoppedNavMeshAgent();
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
