using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemySpawner SpawnPoints;
    public float speed;
    public float timeToWalk = 20;
    int currentWayPoint;
    public float turnSpeed;
    public GameObject Spawner;
    public List<Transform> waypoints;
    EnemyShoot SHOOT;

    private void Start()
    {
        SHOOT = gameObject.GetComponent<EnemyShoot>();
        Spawner = GameObject.FindWithTag("Spawner");
        Spawner.GetComponent<EnemySpawner>();

        
        foreach (Transform waypoint in Spawner.transform)
        {
            waypoints.Add(waypoint);
        }

        currentWayPoint = Random.Range(0, waypoints.Count);
    }


    public void regularPatrol()
    {
        Vector3 pos = transform.position;
        pos = Vector3.MoveTowards(pos, waypoints[currentWayPoint].position, Time.deltaTime * speed);
        timeToWalk -= Time.deltaTime;

        if (pos == waypoints[currentWayPoint].position || timeToWalk < 0)
        {
            currentWayPoint = Random.Range(0, waypoints.Count);

            //currentWayPoint += 1;
            //if (currentWayPoint >= waypoints.Count) currentWayPoint = 0;
            timeToWalk = 20f;
        }

        transform.position = pos;
        LookAtPoint(waypoints[currentWayPoint].position);
    }

    public void LookAtPoint(Vector2 wayPoint)
    {
        float ourNewAngle = Vector2.Angle(Vector2.up, wayPoint - (Vector2)transform.position);
        if (wayPoint.x > transform.position.x) ourNewAngle = -ourNewAngle;

        //transform.eulerAngles = new Vector3(0, 0, ourNewAngle);
        Quaternion newRotation = Quaternion.Euler(new Vector3(0, 0, ourNewAngle));
        Quaternion currentRotation = transform.rotation;

        transform.rotation = Quaternion.RotateTowards(currentRotation, newRotation, Time.deltaTime * turnSpeed);

    }
}
