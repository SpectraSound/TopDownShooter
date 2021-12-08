using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    GameObject player;
    HeroAttack playerAmmo;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAmmo = player.GetComponent<HeroAttack>();
    }
    private void Update()
    {
        gameObject.transform.Rotate(transform.forward, 5);
    }
    public int Ammo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case "Gun":
                    playerAmmo.gunAmmo += Ammo;
                    Destroy(gameObject);
                    break;
                case "Rifle":
                    playerAmmo.rifleAmmo += Ammo;
                    Destroy(gameObject);
                    break;
                case "ShotGun":
                    playerAmmo.shotGunAmmo += Ammo;
                    Destroy(gameObject);
                    break;
                case "Grenade":
                    playerAmmo.grenadeAmmo += Ammo;
                    Destroy(gameObject);
                    break;
                case "FirstAid":
                    player.GetComponent<Health>().hp += 25;
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
            

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
