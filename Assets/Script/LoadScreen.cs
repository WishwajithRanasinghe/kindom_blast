using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private float _LoadTime = 5f;
    [SerializeField] private float _startTime;
    [SerializeField] private Image _loadImage;
    [SerializeField] private Gradient _timerColor;
    private void Start()
    {
        _startTime = 0;
    }
    private void Update()
    {
        _startTime += Time.deltaTime;

        _loadImage.fillAmount = _startTime/_LoadTime;
        _loadImage.color = _timerColor.Evaluate(_loadImage.fillAmount);
        if(_startTime >= _LoadTime)
        {   
            SceneManager.LoadScene(1);
            _startTime = _LoadTime;
            
        }
        
    }
}
