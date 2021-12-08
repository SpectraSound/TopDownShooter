using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
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
                if (hp.hp <= 0 && collision.collider.tag != "Player")
                {
                    collision.collider.GetComponent<DropItem>().DropIt(collision.collider.GetComponent<SpriteRenderer>().sprite);
                    Destroy(collision.gameObject);
                }
                hp.hp -= damage;              
            }

        }
    }
}
