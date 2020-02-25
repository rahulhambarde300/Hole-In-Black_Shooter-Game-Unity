using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnTriggerDestroy : MonoBehaviour
{
    private GameController gameController;
    public GameObject Explosion;
    public int scoreValue;
    void Start()
    {
        GameObject gameControlObject = GameObject.FindWithTag("GameController");
        if (gameControlObject != null)
            gameController = gameControlObject.GetComponent<GameController>();
        if (gameControlObject == null)
            Debug.Log("Sorry ,Couldn't find object");
    }
    void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Player") {
            Instantiate(Explosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(gameObject);
            gameController.decreaseHealth();
            gameController.addScore(scoreValue);


        }

    }
}
