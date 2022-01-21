using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_CS : MonoBehaviour
{
    //public Bullet bulletObj;
    private Rigidbody2D _rigidbody2D;
    public float speed = 500f;
    public float maxlifetime = 10f;
    private void Awake() 
    {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Project(Vector2 direction) 
    {
        _rigidbody2D.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxlifetime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
