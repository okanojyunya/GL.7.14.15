using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    #region@ΟιΎ
    [SerializeField] private Transform _myselfTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _angle;
    [SerializeField] private float _maxDistance = float.PositiveInfinity;
    private Ray _ray;
    private Vector3 _targetDir;
    #endregion
    #region ΐ
    private void Start()
    {

    }
    #endregion
    #region ΦιΎ

    public bool Search()
    {
        var myself = _myselfTransform.position;
        var target = _targetTransform.position;
        var selfDir = _myselfTransform.forward;
        _targetDir = target - myself;
        var targetDistance = target.magnitude;
        var cosHalf = Mathf.Cos(_angle / 2 * Mathf.Deg2Rad);
        var innerProduct = Vector3.Dot(selfDir, _targetDir.normalized);
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
