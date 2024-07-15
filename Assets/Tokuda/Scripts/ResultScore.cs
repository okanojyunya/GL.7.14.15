using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField] private Text _resultText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ScoreManager.score);
        _resultText.text = ScoreManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
