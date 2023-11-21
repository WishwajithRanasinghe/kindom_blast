using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Rigidbody2D _currntObjectRb;
    private float _currentSpeed,_maxHealth;
    private SpriteRenderer _spRender;
    [SerializeField] private float _maxDestroySpeed = 30f,_damageSpeed,_miniDamageSpeed;
    [SerializeField] private float _damage = 100;
    [SerializeField] private Sprite _brokenSprite;
    private void Awake()
    {
        _spRender = GetComponent<SpriteRenderer>();
        
    }
    private void Start()
    {
        _maxHealth = _damage;
    }
    private void Update()
    {
        if(_damage <= 0)
        {
            DestroyObject();
        }
        if(_damage <= _maxHealth/2)
        {
            _spRender.sprite = _brokenSprite;
        }
    
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>() == null) {return;}
        _currntObjectRb = collision.gameObject.GetComponent<Rigidbody2D>();
        _currentSpeed = _currntObjectRb.velocity.magnitude;
        Debug.Log(_currentSpeed + collision.transform.tag);
        if(_maxDestroySpeed <=_currentSpeed)
        {
            DestroyObject();
        }
        else if(_damageSpeed <= _currentSpeed && _maxDestroySpeed >= _currentSpeed)
        {
            _damage -= 30;
        }
        else if(_miniDamageSpeed <= _currentSpeed && _damageSpeed >= _currentSpeed)
        {
            _damage -= 10;
        }

       
    }
    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }//DestroyObjec
}//Class
