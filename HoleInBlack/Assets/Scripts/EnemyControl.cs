using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject playerObject;
    public float velocity = 1;
    public float turnSpeed=10;
    Quaternion targetRotation;
    public float stopDistance;

    public GameObject fireBall;
    public Transform SpawnShot;

    public float fireRate = 1;
    public float nextFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null)
        {
            Rotate();
            if (Vector3.Distance(transform.position, playerObject.transform.position)> stopDistance)
            {
                Move();
            }
            else {
                if ( Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(fireBall, SpawnShot.position, SpawnShot.rotation);
                    GetComponent<AudioSource>().Play();
                }
            }
        }

    }

    void Rotate()
    {
        Vector3 direction = playerObject.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
    void Move()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;


    }
}
