using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public float MaxLife = 5.0f;
    Rigidbody2D Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    public void FireBullet(Vector2 direction)
    {
        Rigidbody.AddForce(direction*speed);
        Destroy(this.gameObject,MaxLife);

    }

  
}
