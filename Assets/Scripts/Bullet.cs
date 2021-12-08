using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public string Owner;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.name != Owner)
        {
            Health hp = collision.collider.GetComponent<Health>();
            if (hp != null)
            {
                hp.hp -= damage;
                Destroy(gameObject);
                if (hp.hp <= 0 && collision.collider.tag != "Player")
                {
                    collision.collider.GetComponent<DropItem>().DropIt(collision.collider.GetComponent<SpriteRenderer>().sprite);
                    Destroy(collision.gameObject);
                    
                }

            }
            
        }

        if (collision.collider.tag == "Bullet" || collision.collider.tag == "EnemyBullet" || collision.collider.tag == "Knife")
        {
            Destroy(gameObject, 1f);
        }
      
    }

}
