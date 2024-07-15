using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneTimer : MonoBehaviour
{
    private float _timer = 0f;
    private float _time = 4f;
    public  GameObject _canvas;
    private void Update()
    {
        _timer += Time.deltaTime;
        Debug.Log($"{_timer}");
        UIActive();
    }

    void UIActive()
    {
        if (_time <= _timer)
        {
            _canvas.SetActive(true);
        }
    }
}
