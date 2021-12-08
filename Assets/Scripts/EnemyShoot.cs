using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletOriginal;
    public Transform[] bulletOrigin;
    public float speed;
    public float maxSight;
    public float fieldOfView = 45f;
    Transform player;
    public LayerMask layerMask;
    EnemyMovement LookAtPlayer;
    SpriteRenderer enemyRenderer;

    public float firerate;
    private float cooldown = 0;



    // Start is called before the first frame update
    void Start()
    {
        LookAtPlayer = gameObject.GetComponent<EnemyMovement>();
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerInSight() && canShoot() /*&& Time.time > cooldown*/)
        {

            LookAtPlayer.LookAtPoint(player.position);
            switch (enemyRenderer.sprite.name)
            {
                case "EnemyGun":
                    Gun();
                    break;

                case "EnemyRifle":
                    AssaultRifle();
                    break;

                case "EnemyShotGun":
                    ShotGun();
                    break;

                default:
                    break;
            }
        }
        else
        {
            LookAtPlayer.regularPatrol();
        }
    }

    public bool isPlayerInSight()
    {
        var lineOfSight = Vector2.Distance(player.position, transform.position);

        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, player.position - transform.position, lineOfSight, layerMask);
        
        //return raycastHit.transform == null;
        if (raycastHit.transform == null && lineOfSight < maxSight)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public bool canShoot()
    {
        if (Vector3.Angle(transform.up, player.transform.position - transform.position) <= fieldOfView)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ShootBullet(int bullets)
    {
        GameObject newBullet = Instantiate(bulletOriginal, bulletOrigin[bullets].position, bulletOrigin[bullets].rotation);

        Rigidbody2D bulletBody = newBullet.GetComponent<Rigidbody2D>();
        bulletBody.velocity = bulletOrigin[bullets].transform.up * speed;
        Destroy(newBullet, 5f);
    }

    private void Gun()
    {
        if (Time.time > cooldown)
        {
            cooldown = Time.time + 1 / firerate;
            ShootBullet(0);
        }

    }

    private void ShotGun()
    {
        if (Time.time > cooldown)
        {
            int bulletCount = 0;
            cooldown = Time.time + 1 / firerate;
            while (bulletCount <= 4)
            {
                ShootBullet(bulletCount);
                bulletCount += 1;
            }
        }

    }

    private void AssaultRifle()
    {
        if (Time.time > cooldown)
        {
            cooldown = Time.time + 1 / firerate;
            ShootBullet(0);
        }

    }

    public void ShootPlayer()
    {
        if (isPlayerInSight() && canShoot() && Time.time > cooldown)
        {

            LookAtPlayer.LookAtPoint(player.position);
            switch (enemyRenderer.sprite.name)
            {
                case "EnemyGun":
                    Gun();
                    break;

                case "EnemyRifle":
                    AssaultRifle();
                    break;

                case "EnemyShotGun":
                    ShotGun();
                    break;

                default:
                    break;
            }
        }
    }
}
