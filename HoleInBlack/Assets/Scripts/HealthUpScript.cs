using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController gameControllerInstance;
    public GameObject Animation;
    void Start()
    {
        
        GameObject gameControlObject = GameObject.FindWithTag("GameController");
        if (gameControlObject != null)
        {
            gameControllerInstance = gameControlObject.GetComponent<GameController>();
        }
        if (gameControlObject == null)
            Debug.Log("Sorry ,Couldn't find object");
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(Animation, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(gameObject);
            gameControllerInstance.increaseHealth();
        }

    }

}
