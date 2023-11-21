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

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }//Awake
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject,_destroyTime);
        Instantiate(_explose,transform.position,Quaternion.identity);
        _audioSource.PlayOneShot(_explosClip);
 
    }//OnCollisionEnter2D

}//Class
