using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float _destroyTime = 3f;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject,_destroyTime);
 
    }//OnCollisionEnter2D

}//Class
