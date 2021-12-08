using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public Animator animator;
    SpriteRenderer heroRenderer;
    public AudioClip GunSound;
    public AudioClip KnifeSound;
    AudioSource source;

    public GameObject bulletOriginal;
    public Transform[] bulletOrigin;

    public float speed;
    public float firerate;
    private float cooldown = 0;

    //Ammunition
    public int gunAmmo;
    public int rifleAmmo;
    public int shotGunAmmo;
    public int grenadeAmmo;
    // Start is called before the first frame update
    void Start()
    {
        heroRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (heroRenderer.sprite.name)
        {
            case "Man":
                KnifeAttack();
                break;

            case "ManGun":
                Gun();
                break;

            case "ManRifle":
                AssaultRifle();
                break;

            case "ManShotGun":
                ShotGun();
                break;

            default:
                break;
        }
    }

    private void KnifeAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Slice"); 
            
        }
    }


    private void AssaultRifle()
    {
        if (Input.GetMouseButton(1) && Time.time > cooldown && rifleAmmo > 0)
        {
            cooldown = Time.time + 1 / firerate;
            ShootBullet(0);
            rifleAmmo -= 1;
        }
    }


    private void Gun()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > cooldown && gunAmmo > 0)
        {
            cooldown = Time.time + 1 / firerate;
            ShootBullet(0);
            gunAmmo -= 1;
        }
    }

    private void ShotGun()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > cooldown && shotGunAmmo > 0)
        {
            int bulletCount = 0;
            cooldown = Time.time + 1 / firerate;
            while (bulletCount <= 4)
            {
                ShootBullet(bulletCount);
                bulletCount += 1;
            }
            shotGunAmmo -= 1;
        }
    }

    public void ShootBullet(int bullets)
    {        
        GameObject newBullet = Instantiate(bulletOriginal, bulletOrigin[bullets].position, bulletOrigin[bullets].rotation);

        Rigidbody2D bulletBody = newBullet.GetComponent<Rigidbody2D>();
        bulletBody.velocity = bulletOrigin[bullets].transform.up * speed;
        Destroy(newBullet, 5f);      
    }
}
