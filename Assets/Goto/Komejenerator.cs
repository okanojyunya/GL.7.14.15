using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komejenerator : MonoBehaviour
{
    [SerializeField] GameObject _kome;
    [SerializeField] float _generateCount = 50f;


    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < _generateCount; i++)
        {
            Instantiate(_kome, RandomVector(), Quaternion.identity);
        }
    }

    /// <summary>ポジションをランダムにする </summary>
    /// <returns></returns>
    private Vector3 RandomVector()
    {
        return new Vector3(Random.Range(-7, 7),0, Random.Range(-13, 13));
    }
}
