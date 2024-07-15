using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

internal class AI : MonoBehaviour
{
    private bool _FlagDe = true;
    #region　変数宣言
    [SerializeField] private Image _Image;
    #region Animation()
    [SerializeField] private Animator _animator;
    public enum AnimationFlag
    {
        isFind,
        isWalk,
        Flow
    }
    #endregion
    #region Search()変数
    [SerializeField] private Transform _myselfTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _angle;
    [SerializeField] private float _maxDistance = float.PositiveInfinity;
    private Ray _ray;
    private Vector3 _targetDir;
    #endregion
    #region AiNavMehs()変数
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _defaultSpeed;
    private NavMeshAgent _navMeshAgent;
    private float _distance;
    private bool _flag = true;
    #endregion
    #region OnDestory()変数
    [SerializeField] private GameObject _gameObject;
    #endregion
    #endregion
    #region 実装
    private void Start()
    {
        Random.InitState((int)Time.deltaTime);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.enabled = true;
        StartCoroutine(AiNavMesh());
    }
    #endregion
    #region 関数宣言

    private IEnumerator AiNavMesh()
    {
        while (true)
        {
            _distance = Vector3.Distance(_myselfTransform.position, _navMeshAgent.destination);
            if (Search() && _flag&&_FlagDe)
            {
                Debug.Log("AA");
                _navMeshAgent.isStopped = true;
                yield return new WaitForSeconds(StartAnimation());
                _navMeshAgent.isStopped = false;
                _navMeshAgent.speed = _runSpeed;
                _flag = false;
                _navMeshAgent.destination = (_myselfTransform.position - _targetDir);
            }
            else if (_distance <= 1)
            {
                _navMeshAgent.speed = _defaultSpeed;
                _navMeshAgent.destination = _myselfTransform.localPosition + RandomVector();
                _animator.SetBool(nameof(AnimationFlag.isWalk), true);
                _animator.SetBool(nameof(AnimationFlag.isFind), false);
                _flag = true;
            }
            yield return null;
        }
    }
    /// <summary>発見アニメーション再生 </summary>
    /// <returns></returns>
    private float StartAnimation()
    {
        _animator.SetBool(nameof(AnimationFlag.isFind), true);
        _animator.SetBool(nameof(AnimationFlag.isWalk), false);
        return 1.0f;
    }
    /// <summary>ポジションをランダムにする </summary>
    /// <returns></returns>
    private Vector3 RandomVector()
    {
        return new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
    }

    private Vector3 RandomVector2()
    {
        return new Vector3(Random.Range(-7, 7), 0, Random.Range(-13, 13));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Rigidbody>(out Rigidbody player))
        {
            _FlagDe = false;
            Instantiate(_gameObject, RandomVector2(), Quaternion.identity);
            ScoreManager.score++;
            Destroy(gameObject);
        }
    }

    private bool Search()
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
                if (hit.collider.TryGetComponent<ISearchableCollider>(out ISearchableCollider rigidbody))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void ImageControlOn()
    {
        _Image.enabled = true;
    }
    public void ImageControlOff()
    {
        _Image.enabled = false;
    }
    public void StoppedNavMeshAgent()
    {
        _navMeshAgent.enabled = false;
    }
    #endregion
}
