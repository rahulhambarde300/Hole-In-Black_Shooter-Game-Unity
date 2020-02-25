using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviour
{
    private GameController gameController;
    public float speed = 20;
    public GameObject hurt;

    void Start()
    {
        GameObject gameControlObject = GameObject.FindWithTag("GameController");
        if (gameControlObject != null)
            gameController = gameControlObject.GetComponent<GameController>();
        if (gameControlObject == null)
            Debug.Log("Sorry ,Couldn't find object");
    }

    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(hurt, other.gameObject.transform.position, other.gameObject.transform.rotation);
            gameController.decreaseHealth();
        }
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

}
