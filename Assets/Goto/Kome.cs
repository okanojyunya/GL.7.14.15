
using UnityEngine;

public class Kome : MonoBehaviour
{
    PlayerMove _player;
    AI _ai;
    [SerializeField]
    Animator _animator;
    bool _hitLaser = false;
    // Start is called before the first frame update
    void Start()
    {
        _ai = GetComponent<AI>();
        _player = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitLaser)
        {
            _animator.Play("Flow");
            Vector3 suikomi = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime * 3f);
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
