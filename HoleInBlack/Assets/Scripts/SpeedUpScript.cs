using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpScript : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject Animation;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControlObject = GameObject.FindWithTag("Player");
        if (gameControlObject != null)
        {
            playerController = gameControlObject.GetComponent<PlayerController>();
        }
        if (gameControlObject == null)
            Debug.Log("Sorry ,Couldn't find object");
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(Animation,transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(gameObject);
            if (playerController.fireRate>0.1f)
                playerController.fireRate -= 0.1f;
        }

    }
}
