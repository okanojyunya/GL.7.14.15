using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationFind : MonoBehaviour
{
    [SerializeField] private Image _Image;
    public void ImageControlOn()
    {
        _Image.enabled = true;
    }
    public void ImageControlOff()
    {
        _Image.enabled = false;
    }
}
