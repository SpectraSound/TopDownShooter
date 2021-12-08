using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
     
    public GameObject EnemyPrefab;
    public Sprite[] EnemySprites;
    public float Spawnrate = 10f;

    public List<Transform> spawnPoints;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
            
        }
        ChooseSprite(SpawnEnemy().GetComponent<SpriteRenderer>());
    }

    private void Update()
    {
        Spawnrate -= Time.deltaTime;

        if (Spawnrate < 0)
        {  
            ChooseSprite(SpawnEnemy().GetComponent<SpriteRenderer>());
            Spawnrate = 10f;
        }
    }
    private GameObject SpawnEnemy()
    {

        int randomSpawnPoint = Random.Range(0, spawnPoints.Count);

        GameObject enemy = Instantiate(EnemyPrefab, spawnPoints[randomSpawnPoint].position,Quaternion.identity);
        return enemy;
    }
    
    private void ChooseSprite(SpriteRenderer enemyRenderer)
    {
        int randomSprite = Random.Range(0, EnemySprites.Length);
        Sprite chosensprite = EnemySprites[randomSprite];
        enemyRenderer.sprite = chosensprite;
    }
    
}
