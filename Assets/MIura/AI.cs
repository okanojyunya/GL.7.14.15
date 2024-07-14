using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    #region�@�ϐ��錾
    #region Animation()
    [SerializeField] private Animator _animator;
    #endregion
    #region Search()�ϐ�
    [SerializeField] private Transform _myselfTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _angle;
    [SerializeField] private float _maxDistance = float.PositiveInfinity;
    private Ray _ray;
    private Vector3 _targetDir;
    #endregion
    #region AiNavMehs()�ϐ�
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _defaultSpeed;
    private NavMeshAgent _navMeshAgent;
    private float _distance;
    private bool _flag = true;
    #endregion
    #region OnDestory()�ϐ�
    [SerializeField] private GameObject _gameObject;
    #endregion
    #endregion
    #region ����
    private void Start()
    {
        Random.InitState((int)Time.deltaTime);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(AiNavMesh());
    }
    #endregion
    #region �֐��錾

    private IEnumerator AiNavMesh()
    {
        while (true)
        {
            _distance = Vector3.Distance(_myselfTransform.position, _navMeshAgent.destination);
            if (Search() && _flag)
            {
                _navMeshAgent.isStopped = true;
                yield return new WaitForSeconds(2);
                _navMeshAgent.isStopped = false;
                _navMeshAgent.speed = _runSpeed;
                _flag = false;
                _navMeshAgent.destination = (_myselfTransform.position - _targetDir)*2;
            }
            else if (_distance <= 1)
            {
                _navMeshAgent.speed = _defaultSpeed;
                _navMeshAgent.destination = _myselfTransform.localPosition + RandomVector();
                _flag = true;
            }
            yield return null;
        }
    }
    /// <summary>�����A�j���[�V�����Đ� </summary>
    /// <returns></returns>
    private float Animation()
    {
        return 1.0f;
    }
    /// <summary>�|�W�V�����������_���ɂ��� </summary>
    /// <returns></returns>
    private Vector3 RandomVector()
    {
        return new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<PlayerMove>(out PlayerMove player))
        {
            Instantiate(_gameObject,RandomVector(),Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public bool Search()
    {
        var myself = _myselfTransform.position;
        var targetPos = _targetTransform.position;
        var selfDirPos = _myselfTransform.forward;
        _targetDir = targetPos - myself;
        var targetDistance = targetPos.magnitude;
        var cosHalf = Mathf.Cos(_angle / 2 * Mathf.Deg2Rad);
        var innerProduct = Vector3.Dot(selfDirPos, _targetDir.normalized);
        if (innerProduct > cosHalf && targetDistance < _maxDistance)
        {
            _ray = new Ray(_myselfTransform.position, _targetDir);
            RaycastHit hit;
            if (Physics.Raycast(_ray, out hit))
            {
                if (hit.collider.TryGetComponent<PlayerMove>(out PlayerMove rigidbody))
                {
                    return true;
                }
            }
        }
        return false;
    }
    #endregion
}
