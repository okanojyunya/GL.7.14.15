using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    //—V‚Ñ•û‚Ìƒpƒlƒ‹
    public GameObject _howtoPanel;

    public void StartAction()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        //DontDestroyOnLoad(gameObject);
    }
    public void HowtoActive()
    {
        _howtoPanel.SetActive(true);
    }
    public void HowtoAnactive()
    {
        _howtoPanel.SetActive(false);
    }
    public void ResetAction()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}
