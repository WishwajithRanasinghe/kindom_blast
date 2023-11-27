using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private float _destroyTime = 3f;
    [SerializeField] private GameObject _explose;
    [SerializeField] private AudioClip _explosClip;
    [SerializeField] private float _yMiniValue,_ymaxValue,_xMiniValue,_xMaxValue;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }//Awake
    private void Update()
    {
        if(transform.position.x < _xMiniValue || transform.position.x > _xMaxValue || transform.position.y < _yMiniValue || transform.position.y > _ymaxValue)
        {
            Destroy();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy();
        Instantiate(_explose,transform.position,Quaternion.identity);
        _audioSource.PlayOneShot(_explosClip);
 
    }//OnCollisionEnter2D
    private void Destroy()
    {
        Destroy(this.gameObject,_destroyTime);
    }

}//Class
