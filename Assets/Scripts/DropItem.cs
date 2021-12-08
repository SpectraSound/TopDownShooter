using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    private SpriteRenderer enemyRenderer;
    private Health enemyHealth;
    public GameObject Gun;
    public GameObject Rifle;
    public GameObject ShotGun;
    public GameObject FirstAid;

    
    void Drop(GameObject item)
    {
        int firstAidDropChance = Random.Range(0, 10);
        if (firstAidDropChance == 5)
        {
            Instantiate(FirstAid, transform.position, transform.rotation);
        }
        Instantiate(item, transform.position, transform.rotation);

    }

    public void DropIt(Sprite sprite)
    {
        switch (sprite.name)
        {
            case "EnemyGun":
                Drop(Gun);
                break;

            case "EnemyRifle":
                Drop(Rifle);
                break;

            case "EnemyShotGun":
                Drop(ShotGun);
                break;
            default:
                break;
        }
    }
}
