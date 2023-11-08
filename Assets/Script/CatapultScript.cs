using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatapultScript : MonoBehaviour
{
    private Rigidbody2D _currentBallRBody;
    private SpringJoint2D _currentSpringJoint;
    private GameObject _spawnBall;
    [SerializeField] private Rigidbody2D _pivot;
    [SerializeField] private GameObject _ballPrefabs;
    [SerializeField] private float _detachDelay = 0.5f,_spawnDelay = 0.5f;

    private bool _isDragging;
    private void Start()
    {
        Respawner();

    }//Start

    private void Update()
    {
        TouchInput();
        
    }// Update 
    private void TouchInput()
    {
        if(_currentBallRBody == null) {return;}
        if(!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if(_isDragging == true)
            {
                LounchBall();
            }
            _isDragging = false;
            return;
            
        }
        _isDragging = true;

        _currentBallRBody.isKinematic = true;
        Vector2 _touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 _worldPosition = Camera.main.ScreenToWorldPoint(_touchPosition);

        _currentBallRBody.position = _worldPosition;

    }//TouchInput
    private void LounchBall()
    {
        _currentBallRBody.isKinematic = false;
        _currentBallRBody = null;
        Invoke(nameof(DetachBall),_detachDelay);

    }//LounchBall

    private void DetachBall()
    {
        _currentSpringJoint.enabled = false;
        _currentSpringJoint = null;
        Invoke(nameof(Respawner),_spawnDelay);

    }//DetachBall
    private void Respawner()
    {
        _spawnBall = Instantiate(_ballPrefabs,_pivot.position,Quaternion.identity);
        _currentBallRBody = _spawnBall.GetComponent<Rigidbody2D>();
        _currentSpringJoint = _spawnBall.GetComponent<SpringJoint2D>();
    
        _currentSpringJoint.connectedBody = _pivot;

        
    }//Respawne
}//Class
