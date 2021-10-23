using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D rigidbody;
    public float size = 1.0f;

    public float Speed = 50f;

    public float Minsize=0.5f;
    public float MaxSize=1.5f;


   

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SpriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);
        transform.localScale = new Vector3(Minsize,MaxSize);

        rigidbody.mass = this.size;
    }
    public void SetTrajectory(Vector2 direction)
    {
        rigidbody.AddForce(direction * Speed);
        Destroy(gameObject, 30f);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            FindObjectOfType<GameManager>().AsteroidDestroy(this);
            Destroy(this.gameObject);
        }
    }





}
