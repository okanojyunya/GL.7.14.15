using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    #region@•Ï”éŒ¾
    #region Search()•Ï”
    [SerializeField] private Transform _myselfTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _angle;
    [SerializeField] private float _maxDistance = float.PositiveInfinity;
    private Ray _ray;
    private Vector3 _targetDir;
    #endregion
    #region AiNavMehs()•Ï”
    [SerializeField]private float _runSpeed=default;
    [SerializeField] private float _defaultSpeed;
    private NavMeshAgent _navMeshAgent;
    private float _distance;
    private bool _flag = true;
    #endregion
    #endregion
    #region À‘•
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(AiNavMesh());
    }
    #endregion
    #region ŠÖ”éŒ¾

    private IEnumerator AiNavMesh()
    {
        while (true)
        {
            _distance = Vector3.Distance(_myselfTransform.position, _navMeshAgent.destination);
            if (Search() && _flag)
            {
                _navMeshAgent.speed = _runSpeed;
                _flag = false;
                _navMeshAgent.destination = (_myselfTransform.position - _targetDir)*2;
            }
            else if (_distance <= 2.0f)
            {
                _navMeshAgent.speed = _defaultSpeed;
                _navMeshAgent.destination = _myselfTransform.localPosition + RandomVector();
                _flag = true;
            }
            yield return null;
        }
    }

    private Vector3 RandomVector()
    {
        return new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
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
                if (hit.collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    return true;
                }
            }
        }
        return false;
    }
    #endregion
}
