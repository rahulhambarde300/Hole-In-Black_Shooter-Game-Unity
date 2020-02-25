using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public float forceFactor = 10f;
    public float speed = 20;
    List<Rigidbody> enemies = new List<Rigidbody>();
    Transform field;
    void Start() {
        field = GetComponent<Transform>();
    }
    void Update()
    {
        Move();

    }
    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void FixedUpdate()
    {
        foreach(Rigidbody enemy in enemies)
        {
            if (enemy != null)
                enemy.AddForce((field.position - enemy.position) * forceFactor * Time.smoothDeltaTime);

            else
                continue;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            enemies.Add(other.GetComponent<Rigidbody>());
    }
}
