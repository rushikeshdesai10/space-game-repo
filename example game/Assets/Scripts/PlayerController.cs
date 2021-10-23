using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float Speed;
    private float RotationOffset = 270;

    public Bullet bulletPrefab;

    private int Count = 0;
    private int limit = 25;

 

   

 
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + RotationOffset));

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);



       
        if( Input.GetKey(KeyCode.Space)&&Count<limit&& Time.frameCount % 30 == 0)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.FireBullet(transform.up);
            
        }
        

    }


   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            FindObjectOfType<GameManager>().Died();
        }
    }

}
